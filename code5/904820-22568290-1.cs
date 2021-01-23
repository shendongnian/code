    public class Baudot {
        public const char Null = 'n';
        public const char ShiftToFigures = 'f';
        public const char ShiftToLetters = 'l';
        private const char Undefined = 'u';
        public const char Wru = 'w';
        public const char Bell = 'b';
        private const string Letters = "nE\nA SIU\rDRJNFCKTZLWHYPQOBGfMXVu";
        private const string Figures = "n3\n- b87\rw4',!:(5\")2#6019?&u./;l";
        public static char? GetFigure(int key) {
            char? c = Figures[key];
            return (c != Undefined) ? c : null;
        }
        public static int? GetFigure(char c) {
            int? i = Figures.IndexOf(c);
            return (i >= 0) ? i : null;
        }
        public static char? GetLetter(int key) {
            char? c = Letters[key];
            return (c != Undefined) ? c : null;
        }
        public static int? GetLetter(char c) {
            int? i = Letters.IndexOf(c);
            return (i >= 0) ? i : null;
        }
    }
