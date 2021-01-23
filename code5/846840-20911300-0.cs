        EnumSource.EnumMember selectedItem;
        public  EnumSource.EnumMember SelectedItem
        { 
            get{return  selectedItem;}
            set { selectedItem = value; OnPropertyChanged("SelectedItem");}
        }
