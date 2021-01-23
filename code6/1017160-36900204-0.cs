        public static class ListViewAttachedBehavior
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.CreateAttached (
                "Command",
                typeof(ICommand),
                typeof(ListViewAttachedBehavior),
                null,
                propertyChanged:OnCommandChanged);
        
        public static ICommand GetCommand (BindableObject view)
        {
            return (ICommand)view.GetValue (CommandProperty);
        }
        public static void SetCommand (BindableObject view, ICommand value)
        {
            view.SetValue (CommandProperty, value);
        }
        static void OnCommandChanged (BindableObject view, object oldValue, object newValue)
        {
            var entry = view as ListView;
            if (entry == null) 
                return;
         
            entry.ItemTapped += (sender, e) => 
                {
                    var command = (newValue as ICommand);
                    if(command == null)
                        return;
                    if(command.CanExecute(e.Item))
                    {
                        command.Execute(e.Item);
                    }
                    
                };
        }
    }
