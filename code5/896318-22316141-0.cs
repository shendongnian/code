    public class Derp
    {
        public Derp()
        {
            listOfStrings = new List<string>();
        }
        public string strName;
        public List<string> listOfStrings;
        public int unrequiredInt;
        public bool unrequiredBool;
        public override bool Equals(object obj)
        {
            return ((Derp) obj).strName.Equals(strName);
        }
        public override int GetHashCode()
        {
            return strName.GetHashCode();
        }
    } 
