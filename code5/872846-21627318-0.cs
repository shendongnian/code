    class ButtonInfo
    {
        public string Caption { get; set; }
        public Point Location { get; set; }
        public Size ButtonSize { get; set; }
        public ButtonInfo(string caption, Point location, Size size )
        {
            this.Caption = caption;
            this.Location = location;
            this.ButtonSize = size;
        }
    }
    class ButtonsCollection : System.Collections.CollectionBase
    {
        public void Add(ButtonInfo bi)
        {
            List.Add(bi);
        }
        public void Remove(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                System.Windows.Forms.MessageBox.Show("Index not valid!");
            }
            else
            {
                List.RemoveAt(index);
            }
        }
        public ButtonInfo Item(int index)
        {
            return (ButtonInfo)List[index];
        }
    }
