    public partial class Options
    {
       public string ValueKey
       {
           get
           {
               return string.Format("{0}-{1}", Value, Key);
           }
       }
    }
