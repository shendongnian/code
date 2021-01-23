            MyControls.Add(a);
            MyControls.Add(b);
        }
        private void MyListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null)
            {
                var selectedItem = listBox.SelectedItems[0] as MyControl;
                var textBlockContent = selectedItem.MyTextBlockContent; //text in textblock
                var labelContent = selectedItem.MyLabelContent; //text in label
            }
        }
        private ObservableCollection<MyControl> _myControls;
        public ObservableCollection<MyControl> MyControls
        {
            get { return _myControls; }
            set
            {
                _myControls = value;
                NotifyPropertyChanged("MyControls");
            }
        }
        #region PropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
