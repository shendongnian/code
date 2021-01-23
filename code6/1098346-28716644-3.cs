    public class AddingNewItemBehavior : Behavior<DataGrid>
    {
        public static readonly DependencyProperty CommandProperty
            = DependencyProperty.Register("Command", typeof(ICommand), typeof(AddingNewItemBehavior), new PropertyMetadata());
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        protected override void OnAttached()
        {
            AssociatedObject.AddingNewItem += AssociatedObject_OnAddingNewItem;
        }
        private void AssociatedObject_OnAddingNewItem(object sender, AddingNewItemEventArgs addingNewItemEventArgs)
        {
            AddingNewItem addingNewItem = new AddingNewItem();
            Command.Execute(addingNewItem);
            addingNewItemEventArgs.NewItem = addingNewItem.NewItem;
        }
    }
