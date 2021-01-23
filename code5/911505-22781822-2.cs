    public class CustomControl:Control
    {
        private Button _button;
        private Label _label;
        public CustomControl(Button button, Label label)
        {
            _button = button;
            _label = label;
            Height = button.Height + label.Height;
            Width = Math.Max(button.Width, label.Width);
            Controls.Add(_button);
            _button.Location = new Point(0,0);
            Controls.Add(_label);
            _label.Location = new Point(0, button.Height);
        }
    }
