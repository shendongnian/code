    public class PositionComparer : IComparer<string>
    {
       private ArrayList Keys {get; set;}
       
       public PositionComparer(ArrayList keys)
       {
           Keys = keys;
       }
       
       public int Compare(string s1, string s2)
       {
           return Keys.IndexOf(s1).CompareTo(Keys.IndexOf(s2));
       }
    }
