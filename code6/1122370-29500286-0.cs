    public class Prompt
    {
        public struct CursorPosition
        {
            public int CursorLeft;
            public int CursorTop;
        }
        private CursorPosition _savedPosition;
        public Prompt Write(string prompt)
        {
            Console.Write(prompt);
            return this;
        }
        public Prompt Write(string promptFormat, params object[] args)
        {
            return Write(string.Format(promptFormat, args));
        }
        public Prompt WriteLine(string prompt)
        {
            Write(prompt);
            Console.WriteLine();
            return this;
        }
        public Prompt WriteLine(string promptFormat, params object[] args)
        {
            return WriteLine(string.Format(promptFormat, args));
        }
        public string ReadLine(bool advanceCursorOnSameLine = false, bool eraseLine = false)
        {
            if (advanceCursorOnSameLine || eraseLine)
            {
                SavePosition();
                if (eraseLine)
                    WriteLine(new string(' ', Console.WindowWidth - _savedPosition.CursorLeft)).RestorePosition();
            }
            var input = Console.ReadLine();
            if (advanceCursorOnSameLine)
                RestorePosition(input.Length);
            return input;
        }
        public Prompt SavePosition()
        {
            _savedPosition = GetCursorPosition();
            return this;
        }
        public CursorPosition GetCursorPosition()
        {
            return new CursorPosition {
                CursorLeft = Console.CursorLeft,
                CursorTop = Console.CursorTop
            };
        }
        public Prompt RestorePosition(CursorPosition position, int deltaLeft = 0, int deltaTop = 0)
        {
            var left = Math.Min(Console.BufferWidth - 1, Math.Max(0, position.CursorLeft + deltaLeft));
            var right = Math.Min(Console.BufferHeight - 1, Math.Max(0, position.CursorTop + deltaTop));
            Console.SetCursorPosition(left, right);
            return this;
        }
        public Prompt RestorePosition(int deltaLeft = 0, int deltaTop = 0)
        {
            return RestorePosition(_savedPosition, deltaLeft, deltaTop);
        }
    }
