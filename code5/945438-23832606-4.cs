    propertyGrid1.SelectedGridItemChanged += OnPropertyGridSelectedGridItemChanged;
        public static void OnPropertyGridSelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            PropertyGrid pg = (PropertyGrid)sender;
            GridItem item = e.NewSelection;
            // yes, a grid item is also an IServiceProvider
            IServiceProvider sp = (IServiceProvider)item;
            // get the property grid view control
            IWindowsFormsEditorService svc = (IWindowsFormsEditorService)sp.GetService(typeof(IWindowsFormsEditorService));
            // WARNING: hack time! this uses private members, so use at your own risks...
            TextBox edit = (TextBox)svc.GetType().GetProperty("Edit", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(svc, null);
            // is this our funky stuff?
            if (item.PropertyDescriptor.GetEditor(typeof(UITypeEditor)) is NoneEditor)
            {
                edit.MaxLength = 10;
                edit.BackColor = Color.Blue;
            }
            else // don't forget to reset the edit box here
            {
                edit.MaxLength = int.MaxValue;
                edit.BackColor = Color.White;
            }
        }
