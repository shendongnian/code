    public partial class User { 
        public string FormattedLinkCode 
         { 
            get { return LinkCode.Last().ToString(); } 
         }
    }
