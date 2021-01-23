       public ICollectionView combo2
        {
            get { return (ICollectionView)GetValue(combo2Property); }
            set { SetValue(combo2Property, value); }
        }
        // Using a DependencyProperty as the backing store for combo2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty combo2Property =
            DependencyProperty.Register("combo2", typeof(ICollectionView), typeof(View), new PropertyMetadata(null));
        public object selectedTeam
        {
            get { return (object)GetValue(selectedTeamProperty); }
            set { SetValue(selectedTeamProperty, value); }
        }
        // Using a DependencyProperty as the backing store for selectedTeam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedTeamProperty =
            DependencyProperty.Register("selectedTeam", typeof(object), typeof(View), new PropertyMetadata(null, OnSelectedTeamChange));
