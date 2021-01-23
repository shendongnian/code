    public static class SudokuCache
    {
        private static Sudoku _game;
        private static DateTime _timestamp;
	    public static Sudoku Game
	    {
            get {
                if (_timestamp.AddMinutes(20) < DateTime.Now) {
                    _game = new Sudoku();
                    _timestamp = new DateTime.Now;
                }
                return _game;
            }
	}
    }
    public class Sudoku { }
