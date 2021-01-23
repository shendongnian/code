    class ContainerViewModel : XElementTreeNodeViewModel
    {
        public ContainerViewModel(XElement node) : base(node) { }
        public override string Text
        {
            get
            {
                return Model.Element(Namespace + "ContainerName").TextValue();
            }
        }
        public override IEnumerable<ITreeNodeViewModel> Children
        {
            get { return Enumerable.Empty<ITreeNodeViewModel>(); }
        }
    }
    class ClassificationViewModel : XElementTreeNodeViewModel
    {
        public ClassificationViewModel(XElement node) : base(node) { }
        public override string Text
        {
            get
            {
                return Model.Element(Namespace + "ClassificationName").TextValue();
            }
        }
        public override IEnumerable<ITreeNodeViewModel> Children
        {
            get
            {
                return Model.Elements(Namespace + "Containers").Elements<XElement>(Namespace + "Container").Select(xn => (ITreeNodeViewModel)new ContainerViewModel(xn));
            }
        }
    }
    class GroupViewModel : XElementTreeNodeViewModel
    {
        public GroupViewModel(XElement node) : base(node) { }
        public override string Text
        {
            get
            {
                return Model.Element(Namespace + "GroupName").TextValue();
            }
        }
        public override IEnumerable<ITreeNodeViewModel> Children
        {
            get
            {
                return Model.Elements(Namespace + "Classifications").Elements<XElement>(Namespace + "Classification").Select(xn => (ITreeNodeViewModel)new ClassificationViewModel(xn));
            }
        }
    }
