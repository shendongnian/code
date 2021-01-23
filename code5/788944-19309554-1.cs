        public class ConsoleStream: StreamReader {
            public ConsoleStream(): base(new MemoryStream()) {}
            public override int Read() {
                var key = Console.ReadKey(true);
                return (int) key.KeyChar;
                }
            }
