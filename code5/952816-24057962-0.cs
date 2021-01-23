    public int count = 0;
        public Button btn1;
        public Button btn2;
        public TextBox txt1;
        private void btn_addnewrow_Click(object sender, RoutedEventArgs e)
        {
            //Creating Rows..
            RowDefinition row0 = new RowDefinition();
            row0.Height = new GridLength(40);
            grid1.RowDefinitions.Add(row0);
            //Creating columns..
            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            col0.Width = new GridLength(50);
            col1.Width = new GridLength(100);
            col2.Width = new GridLength(70);
            grid1.ColumnDefinitions.Add(col0);
            grid1.ColumnDefinitions.Add(col1);
            grid1.ColumnDefinitions.Add(col2);
            int i = count;
            Test t = new Test();
            ////1st Column button
            btn1 = new Button();
            btn1.Margin = new Thickness(10, 10, 0, 0);
            btn1.BorderThickness = new Thickness(0);
            Grid.SetRow(btn1, i);
            Grid.SetColumn(btn1, 0);
            Binding binding = new Binding();
            binding.Source = t;
            btn1.SetBinding(Button.TagProperty, binding);
            btn1.Click += btnBindList_Click;
            grid1.Children.Add(btn1);
            Binding binding1 = new Binding("Content");
            binding1.Source = t;
            //2nd column Textbox 
            txt1 = new TextBox();
            txt1.Margin = new Thickness(10, 10, 0, 0);
            txt1.Name = "txt" + i;
            txt1.SetBinding(TextBox.TextProperty, binding1);
            Grid.SetRow(txt1, i);
            Grid.SetColumn(txt1, 1);
            txt1.Tag = txt1;
            grid1.Children.Add(txt1);
            count++;
        }
        private void btnBindList_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
            t = ((Button)sender).Tag as Test;
        }
        Test t;
        private void ListView1_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            t.Content = (ListView1.SelectedItem as ListViewItem).Content.ToString();
            popup.IsOpen = false;
        }
    }
    class Test : INotifyPropertyChanged
    {
        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
