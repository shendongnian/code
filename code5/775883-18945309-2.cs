    private class ControlGroup
    {
        public Button Button { get; set; }
        public CheckBox CheckBox { get; set; }
        public void Hide()
        {
            this.Button.Hide();
            this.CheckBox.Hide();
        }
    }
