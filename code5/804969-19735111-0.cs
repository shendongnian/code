        static bool TryReadLine(out string result) {
            var buf = new StringBuilder();
            for (; ; ) {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.F4) {
                    result = "";
                    return false;
                }
                else if (key.Key == ConsoleKey.Enter) {
                    result = buf.ToString();
                    return true;
                }
                else if (key.Key == ConsoleKey.Backspace && buf.Length > 0) {
                    buf.Remove(buf.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (key.KeyChar != 0) {
                    buf.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
        }
