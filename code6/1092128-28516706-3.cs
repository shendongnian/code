    class myCheckedColumn : DataGridViewTextBoxColumn
    {
        public bool IsChecked { get; set; }
        public myCheckedColumn ()               { IsChecked = false;    }
        public myCheckedColumn (bool checked_)  { IsChecked = checked_; }
    }
