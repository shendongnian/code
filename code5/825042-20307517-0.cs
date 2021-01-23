    public class GridModel : PropertyChangedBase
    {
        private List<string> leftValue = new List<string> { "Alpha", "Beta", "Gamma" };
        public List<string> LeftValue 
        { 
            get
            {
                return leftValue;
            }
            set
            {
                leftValue = value;
            } 
        }
        [...]
    }
