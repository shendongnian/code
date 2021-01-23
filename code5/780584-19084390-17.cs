    public class ItemsControlSampleViewModel
    {
        public ObservableCollection<ItemsControlSampleData> Data { get; set; }
        
        public Command AddNewRowCommand { get; set; }
        public Command<ItemsControlSampleData> Command1 { get; set; }
        public Command<ItemsControlSampleData> Command2 { get; set; }
        public ItemsControlSampleViewModel()
        {
            var sampledata = Enumerable.Range(0, 10)
                                       .Select(x => new ItemsControlSampleData()
                                                    {
                                                        Label1Text = "Label1 " + x.ToString(),
                                                        Text = "Text" + x.ToString()
                                                    });
            Data = new ObservableCollection<ItemsControlSampleData>(sampledata);
            AddNewRowCommand = new Command(AddNewRow);
            Command1 = new Command<ItemsControlSampleData>(ExecuteCommand1);
            Command2 = new Command<ItemsControlSampleData>(ExecuteCommand2);
            
        }
        private void AddNewRow()
        {
            Data.Add(new ItemsControlSampleData() {Label1Text = "Label 1 - New Row", Text = "New Row Text"});
        }
        private void ExecuteCommand1(ItemsControlSampleData data)
        {
            MessageBox.Show("Command1 - " + data.Label1Text);
        }
        private void ExecuteCommand2(ItemsControlSampleData data)
        {
            MessageBox.Show("Command2 - " + data.Label1Text);
        }
    }
