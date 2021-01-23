     public string DisplayName
     {
         get
         {
             if(this.Category != null)
             {
                 return string.format("{0} - {1}",this.Category.category,this.Desc);
             }
             else
             {
                 return String.Empty;
             }
         }
     }
