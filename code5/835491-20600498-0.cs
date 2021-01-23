    public class Base
    {
        private readonly string delimiter;
        protected Base(string delimiter)
        {
            this.delimiter = delimiter;
        }
    
        // Quite possibly no need for this to be virtual at all
        public void ParseFile(string fileContents)
        {
            string my3dPoints = fileContents.Split(delimiter)[1];
        }
    }
