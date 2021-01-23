    public class ReadOnlyCheckBox : CheckBox
    {
        public bool ReadOnly { get; set; }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!ReadOnly)
            {
                base.OnKeyUp(e);
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!ReadOnly)
            {
                base.OnKeyDown(e);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!ReadOnly)
            {
                base.OnMouseUp(e);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!ReadOnly)
            {
                base.OnMouseDown(e);
            }
        }
    }
    public class ReadOnlyComboBox : ComboBox
    {
        public bool ReadOnly { get; set; }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (ReadOnly)
            {
                e.Handled = true;
            }
            else
                base.OnKeyUp(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (ReadOnly)
            {
                e.Handled = true;
            }
            else
                base.OnKeyDown(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!ReadOnly)
                base.OnMouseDown(e);
            else
            {
                Enabled = false;
                Enabled = true;
                this.Focus();
            }
        }
    }
