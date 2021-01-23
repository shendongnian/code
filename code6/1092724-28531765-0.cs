    public abstract class AModelBase {
        // non-generic stuff
        protected readonly String _name;
        protected readonly String _urlStr;
        protected String _title;
    }
    public abstract class AModel<T,U> : AModelBase where T : class where U : class
    {
        // generic stuff
        protected IList<U> _children;
        protected readonly T _parent;    
    }
    
    public APanel(AModelBase model)
    {
        InitializeComponent();
        _titleLabel.SetTitleString(model.Title);
    }
