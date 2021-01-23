    static IObservable<string> Packets(IObservable<char> source)
    {
        return Observable.Create<string>(observer =>
        {
            var packet = new List<char>();
            Action yieldPacket = () =>
            {
                if (packet.Count > 0)
                {
                    observer.OnNext(new string(packet.ToArray()));
                    packet.Clear();
                }
            };
            return source.Subscribe(
                c =>
                {
                    if (char.IsLetter(c))
                    {
                        yieldPacket();
                    }
                    packet.Add(c);
                },
                observer.OnError,
                () =>
                {
                    yieldPacket();
                    observer.OnCompleted();
                });
        });
    }
