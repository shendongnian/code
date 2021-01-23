    public partial class User { 
        public string FormattedLinkCode 
         { 
            get { 
                    if(string.IsNullOrEmpty(LinkCode))
                         return string.Empty;
                    return LinkCode.Last().ToString(); 
                } 
         }
    }
