    public interface ICompetitor {
        string GetFinalPosition();
    }
    public class Winner : ICompetitor{
        public string GetFinalPosition() {
            return "Won";
        }
    }
    public class Loser : ICompetitor {
        public string GetFinalPosition() {
            return "Lost";
        }
    }
