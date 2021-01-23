    public class ComboBoxList<TCustomType>
    {
        private System.Windows.Forms.ComboBox.ObjectCollection _baseList;
        public ComboBoxList(System.Windows.Forms.ComboBox.ObjectCollection baseItems)
        {
            _baseList = baseItems;
        }
        public TCustomType this[Int32 index]
        {
            get { return (TCustomType)_baseList[index]; }
            set { _baseList[index] = value; }
        }
        public void Add(TCustomType item)
        {
            _baseList.Add(item);
        }
        public Int32 Count { get { return _baseList.Count; } }
    }
