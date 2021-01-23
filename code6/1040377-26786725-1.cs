    public class LabelTextResourced: Label
    {
        private string _textResourceName;
        public string TextResourceName
        {
            get { return _textResourceName; }
            set
            {
                _textResourceName = value;
                if (!string.IsNullOrEmpty(_textResourceName))
                    base.Text = Properties.Resources.ResourceManager.GetString(_textResourceName);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                // Set is done by resource name.
            }
        }
    }
