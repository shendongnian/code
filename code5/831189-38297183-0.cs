        public List<string> ItemSource { get; } = new List<string> { "Item1", "Item2", "Item3" };
        public int TheSelectedIndex { get; set; }
        string _theSelectedItem = null;
        public string TheSelectedItem
        {
            get { return this._theSelectedItem; }
            set
            {
                this._theSelectedItem = value;
                this.RaisePropertyChangedEvent("TheSelectedItem"); 
            } 
        }
