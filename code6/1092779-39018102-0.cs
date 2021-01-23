      public List<EntitySet> EntitySets { get; set; }
      public EntitySetsForm( List<EntitySet> entitySets )
      {
         InitializeComponent();
         EntitySets = entitySets;
         dataGrid.ItemsSource = entitySets;
      }
      private void dataGrid_MouseDoubleClick( object sender, MouseButtonEventArgs e )
      {
         EntitySet entitySet = dataGrid.SelectedItem as EntitySet;
         if ( entitySet == null ) return;
