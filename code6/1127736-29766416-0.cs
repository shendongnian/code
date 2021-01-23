    [DefaultBindingProperty("Selected")]
    public class RadioGroupBox : GroupBox
    {
        #region events
        [Description("Occurs when the selected value changes.")]
        public event SelectedChangedEventHandler SelectedChanged;
        public class SelectedChangedEventArgs : EventArgs
        {
            public int Selected { get; private set; }
            internal SelectedChangedEventArgs(int selected)
            {
                this.Selected = selected;
            }
        }
        public delegate void SelectedChangedEventHandler(object sender, SelectedChangedEventArgs e);
        #endregion
        private int selected;
        [Browsable(false)]
        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        [Description("The selected value associated with this control."), Category("Data")]
        public int Selected
        {
            get { return selected; }
            set
            {
                int val = 0;
                var radioButton = this.Controls.OfType<RadioButton>()
                    .FirstOrDefault(radio =>
                        radio.Tag != null
                       && int.TryParse(radio.Tag.ToString(), out val) && val == value);
                if (radioButton != null)
                {
                    radioButton.Checked = true;
                    selected = val;
                }
            }
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            var radioButton = e.Control as RadioButton;
            if (radioButton != null)
                radioButton.CheckedChanged += radioButton_CheckedChanged;
        }
        protected void OnSelectedChanged(SelectedChangedEventArgs e)
        {
            if (SelectedChanged != null)
                SelectedChanged(this, e);
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            int val = 0;
            if (radio.Checked && radio.Tag != null
                 && int.TryParse(radio.Tag.ToString(), out val))
            {
                selected = val;
                OnSelectedChanged(new SelectedChangedEventArgs(selected));
            }
        }
    }
