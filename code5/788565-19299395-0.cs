    public class MenuItem : ModelBase<MenuItem>
    {
        private List<MenuItem> _Items;
        public MenuItem(string header, ICommand command)
        {
            Header = header;
            Command = command;
        }
        public MenuItem()
        {
            
        }
        public string Header { get; set; }
        public List<IMenuItem> Items
        {
            get { return _Items ?? (_Items = new List<IMenuItem>()); }
            set { _Items = value; }
        }
        public ICommand Command { get; set; }
        public string CommandName { get; set; }
        public object Icon { get; set; }
        public bool IsCheckable { get; set; }
        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                NotifyPropertyChanged(m=>m.IsChecked);
            }
        }
        public bool Visible { get; set; }
        public bool IsSeparator { get; set; }
        public string InputGestureText { get; set; }
        public string ToolTip { get; set; }
        public int MenuHierarchyID { get; set; }
        public int ParentMenuHierarchyID { get; set; }
        public string IconPath { get; set; }
        public bool IsAdminOnly { get; set; }
        public object Context { get; set; }
        public IMenuItem Parent { get; set; }
        public int int_Sequence { get; set; }
        public int int_KeyIndex { get; set; }
    }
