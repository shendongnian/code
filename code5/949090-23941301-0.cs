    public class dataNameValueComparer : IComparer<dataNameValue>
    {
        public int Compare(dataNameValue x, dataNameValue y)
        {
            //Here process your comparation
            //return  <0 if x<y 
            // 0 if x=y 
            // >0 if x>y
            //This sample return the default string compration
            return string.Compare(x.Size, y.Size);
        }
    }
