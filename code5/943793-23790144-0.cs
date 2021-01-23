    var strings = Observable.Create(observer => {
                var sb = new StringBuilder();
                return serialPortSource.Subscribe(characters => {
                        foreach (var ch in characters)
                        {
                            if (ch == '$' && sb.Length > 0)
                            {
                                observer.onNext(sb.ToString());
                                sb.Clear();
                            }
                            sb.Append(ch);
                        }
                    });
            });
