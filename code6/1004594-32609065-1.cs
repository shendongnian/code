    public Win32599087()
            {
                InitializeComponent();
                    
                MemberShipGridNormal.DataContext = myCollection;
    
                Binding b = new Binding();
                b.Source =  myCollection;
                b.Path = new PropertyPath("collectionpropertyname");
    
                BindingOperations.SetBinding(CmbMemberships, DataGridComboBoxColumn.ItemsSourceProperty, b);
            }
