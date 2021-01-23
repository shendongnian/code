        public static IObservable<string> GetCompleteMessage(this IObservable<byte[]> source)
        {
            const byte byteLineFeed = 10;
            IEnumerable<byte> remanider = Enumerable.Empty<byte>();
            Func<byte[], IEnumerable<string>> selector = data =>
            {
                var result = new List<string>();
                var current = new ArraySegment<byte>(data);
                while (true)
                {
                    var dividerOffset = ((IList<byte>)current).IndexOf(byteLineFeed);
                    if (dividerOffset == -1) // No newline found
                    {
                        remanider = remanider.Concat(current);
                        break;
                    }
                    var segment = new ArraySegment<byte>(current.Array, current.Offset, dividerOffset);
                    var lineBytes = remanider.Concat(segment).ToArray();
                    result.Add(Encoding.ASCII.GetString(lineBytes));
                    remanider = Enumerable.Empty<byte>();
                    current = new ArraySegment<byte>(current.Array, current.Offset + dividerOffset + 1, current.Count - 1 - dividerOffset);
                }
                return result;
            };
            return source.SelectMany(selector);
        }
