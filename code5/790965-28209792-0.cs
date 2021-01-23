    public class NameWrapper
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public NameWrapper()
        {
            this.FirstName = "";
            this.LastName = "";
        }
    }
     public static NameWrapper SplitName(string inputStr, char splitChar)
       {
           NameWrapper w = new NameWrapper();
           string[] strArray = inputStr.Trim().Split(splitChar);
           if (string.IsNullOrEmpty(inputStr)){
               return w;
           }
           for (int i = 0; i < strArray.Length; i++)
           {
               if (i == 0)
               {
                   w.FirstName = strArray[i];
               }
               else
               {
                   w.LastName += strArray[i] + " ";
               }
           }
           w.LastName = w.LastName.Trim();
           return w;
       }
