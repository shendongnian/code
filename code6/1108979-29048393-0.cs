    private class MyListBox : System.Windows.Controls.ListBox
    {
        public string[] FullFilesPathsList { get; set; }
        public MyListBox(ListBox listBox)
        {
            this.listBox = listBox;
        }
        private ListBox listBox;
        public string Name { get { return listBox.Name; } }
    }
