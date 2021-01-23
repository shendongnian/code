    class myCheckedCell : DataGridViewTextBoxColumn
    {
        public bool IsChecked { get; set; }
        public myCheckedCell()               { IsChecked = false;    }
        public myCheckedCell(bool checked_)  { IsChecked = checked_; }
    }
