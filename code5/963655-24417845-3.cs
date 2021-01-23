    static IObservable<string> Packets(IObservable<char> source)
    {
        return Observable.Create<string>(observer =>
        {
            var packet = new List<char>();
            Action emitPacket = () =>
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
                        emitPacket();
                    }
                    packet.Add(c);
                },
                observer.OnError,
                () =>
                {
                    emitPacket();
                    observer.OnCompleted();
                });
        });
    }
