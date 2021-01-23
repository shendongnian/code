        public static void WriteInColor(string format, ConsoleColor foreground, ConsoleColor background, params object[] args)
        {
            ConsoleColor prevForeground = Console.ForegroundColor;
            ConsoleColor prevBackground = Console.BackgroundColor;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(format, args);
            Console.ForegroundColor = prevForeground;
            Console.BackgroundColor = prevBackground;
            Console.Out.Flush();
        }
