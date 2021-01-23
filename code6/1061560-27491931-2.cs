    public class Progressor
    {
        private string _first = "something";
        private string _second = GetMyString();
        private string _third = "hey!";
        private string GetMyString()
        {
            return _third.Substring(0, 1);
        }
    }
