    public abstract class ItemBase : IMyItem
    {
    	public string cTitle { get; set; }
    	public string cDescription { get; set; }
        public virtual bool Error 
        { 
          get { return TitleError || DescriptionError; } 
        }
        public virtual bool TitleError 
        { 
          get { return string.IsNullOrEmpty(cTitle); } 
        }
    	public virtual bool DescriptionError 
        { 
          get { return string.IsNullOrEmpty(cDescription); } 
        }
    }
