    class Form2 : Form
    {
        public ListView.SelectedListViewItemCollection ListViewSelectedItems
        {
            get { return yourListView.SelectedItems; }
        }
    }
    class Form1 : Form
    {
        public void SomeMethod()
        {
            var items = myForm2Instance.ListViewSelectedItems;//Use it
            foreach (var item in items)
            {
               //Do whatever
            }
        }
    }
