    public abstract class ItemBase : IMyItem
    {
    	public string cTitle { get; set; }
    	public string cDescription { get; set; }
        public virtual bool Error { get { return item.TitleError() || item.DescriptionError(); } }
        public virtual bool TitleError { get { return string.IsNullOrEmpty(item.cTitle); } }
    	public virtual bool DescriptionError { get { return string.IsNullOrEmpty(item.cDescription; } }
    }
