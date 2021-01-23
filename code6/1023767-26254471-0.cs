    internal class ViewModel
    {
        public ObservableCollection<string> MyObservableCollection { get; set; }
        public string MyString
        {
            get { return string.Join(",", MyObservableCollection); }
            set { // update observable collection here based on value }
        }
    }
    <TextBox Text="{Binding MyString, Mode=TwoWay}"/>
