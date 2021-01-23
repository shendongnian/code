    <CheckBox IsChecked="{Binding ShowComboBoxItemsA}"/>
    <ComboBox ItemsSource="{Binding ComboBoxItems}"/> 
        public List<object> ItemsA { get; set; }
        public List<object> ItemsB { get; set; }
        bool showComboBoxItemsA;
        public bool ShowComboBoxItemsA
        {
            get { return showComboBoxItemsA; }
            set
            {
                if (showComboBoxItemsA != value)
                {
                    showComboBoxItemsA = value;
                    OnPropertyChanged("ShowComboBoxItemsA");
                    if (showComboBoxItemsA)
                        ComboBoxItems = ItemsA;
                    else
                        ComboBoxItems = ItemsB;
                }
            }
        }
        List<object> comboBoxItems;
        public List<object> ComboBoxItems
        {
            get { return comboBoxItems; }
            set
            {
                comboBoxItems = value;
                OnPropertyChanged("ComboBoxItems");
            }
        }
