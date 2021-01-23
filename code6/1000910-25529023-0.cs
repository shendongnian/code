            var timer = new System.Threading.Timer(
                e =>
                {
                    var p = GetCursorPosition();
                    Console.WriteLine(string.Format("X: {0}, Y: {1}", p.X, p.Y));
                },
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5));
