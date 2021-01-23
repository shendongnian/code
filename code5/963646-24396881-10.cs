    public static class ObservableExtensions
    {
        private const int MaxPacketLength = 7;
        private static Dictionary<char, int> PacketLengthTable =
            new Dictionary<char, int> { {'A', 5}, {'B', 6}, {'C', 7 } };
    
        public static IObservable<string> GetPackets(this IObservable<char> source)
        {
            return Observable.Create<string>(o =>
            {
                var currentPacketLength = 0;
                var buffer = new char[MaxPacketLength];
                var index = -1;
                return source.Subscribe(
                    c => {
                        if (Char.IsLetter(c))
                        {
                            currentPacketLength = PacketLengthTable[c];
                            buffer[0] = c;
                            index = 0;
                        }
                        else if(index >= 0)
                        {
                            index++;
                            buffer[index] = c;
                        }
                        if (index == currentPacketLength - 1)
                        {
                            o.OnNext(new string(buffer,0, currentPacketLength));
                            index = -1;
                        }
                    },
                    o.OnError,
                    o.OnCompleted);
            });
        }
    }
