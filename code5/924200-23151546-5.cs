    public class MyViewModel
    {
        public MyViewModel()
        {
            MyCommand = new DelegateCommand(YourMethodWhichSavesToXml());
        }
        public ICommand MyCommand { get; set; }
        public ObservableCollection<MyItem> MyItems { get; set; }
        public MyItem MySelectedItem { get; set; }
        private void YourMethodWhichSavesToXml()
        {
            var serializer = new XmlSerializer(typeof(MyItem));
            using (var writer = new XmlTextWriter(@"C:\mylocation", Encoding.UTF8))
            {
                serializer.Serialize(MySelectedItem, writer);
            }
        }
    }
