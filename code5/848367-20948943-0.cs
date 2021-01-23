    public sealed class Child : INotifyPropertyChanged
    {
        private Child() { }
        public static Child CreateAndAddChild(Parent parent)
        {
            var child = new Child();
            child.Parent = parent;
        }
    
        public Parent Parent
        {
            get { return parent; }
            set
            {
                parent = value;
                parent.Children.Add( this);
                OnPropertyChanged( "Parent" );
            }
        }
    }
