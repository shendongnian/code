    public class GridModel : PropertyChangedBase
    {
        private readonly _leftValue = new List<string> { "Alpha", "Beta", "Gamma" };
        public List<string> LeftValue
        {
        	get { return _leftValue; }
        	set {_leftvValue = value;}
        }    
    }
