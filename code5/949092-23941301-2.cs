    public class SizeComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                //Here process your comparation
                //return  <0 if x<y 
                // 0 if x=y 
                // >0 if x>y
                //This sample return the default string compration
                return string.Compare(x, y);
            }
        }
