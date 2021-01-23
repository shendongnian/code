    class Form1 : Form
    {
        public ListView.SelectedListViewItemCollection ListViewSelectedItems
        {
            get { return yourListView.SelectedItems; }
        }
    }
    class Form2 : Form
    {
        public void SomeMethod()
        {
            Form1 myForm1Instance = ...;//Get instance somehow
            var items = myForm1Instance.ListViewSelectedItems;//Use it
            foreach (var item in items)
            {
               //Do whatever
            }
        }
    }
