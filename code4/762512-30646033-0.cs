        public string Watermark { get; set; }
        protected override void OnSelectedDateChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectedDateChanged(e);
            //SetWatermark();
        }
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            SetWatermark();
        }
        private void SetWatermark()
        {
            FieldInfo fiTextBox = typeof(DatePicker).GetField("_textBox", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiTextBox != null)
            {
                DatePickerTextBox dateTextBox = (DatePickerTextBox)fiTextBox.GetValue(this);
                if (dateTextBox != null)
                {
                    if (string.IsNullOrWhiteSpace(this.Watermark))
                    {
                        this.Watermark = "Custom watermark";
                    }
