    class myCheckedColumn : DataGridViewTextBoxColumn
    {
        public bool IsChecked { get; set; }
        public myCheckedColumn ()               { IsChecked = false;    }
        public myCheckedColumn (bool checked_)  { IsChecked = checked_; }
        public override object Clone()
        {
            myCheckedColumn clone = (myCheckedColumn)base.Clone();
            myCheckedColumn.IsChecked = IsChecked;
            return clone;
        }
    }
