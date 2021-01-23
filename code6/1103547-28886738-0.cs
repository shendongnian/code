    public interface ITreeNodeViewModel
    {
        string Name { get; }
        string Text { get; }
        object Tag { get; }
        object Model { get; }
        IEnumerable<ITreeNodeViewModel> Children { get; }
    }
    public abstract class TreeNodeViewModel<T> : ITreeNodeViewModel
    {
        readonly T model;
        public TreeNodeViewModel(T model)
        {
            this.model = model;
        }
        public T Model { get { return model; } }
        #region ITreeNodeProxy Members
        public abstract string Name { get; }
        public abstract string Text { get; }
        public virtual object Tag { get { return this; } } 
        public abstract IEnumerable<ITreeNodeViewModel> Children { get; }
        #endregion
        #region ITreeNodeViewModel Members
        object ITreeNodeViewModel.Model
        {
            get { return Model; }
        }
        #endregion
    }
    public abstract class XElementTreeNodeViewModel : TreeNodeViewModel<XElement>
    {
        public XElementTreeNodeViewModel(XElement node) : base(node) {
            if (node == null)
                throw new ArgumentNullException();
        }
        public XNamespace Namespace { get { return Model.Name.Namespace; } }
        public override string Name
        {
            get { return Model.Name.ToString();  }
        }
    }
