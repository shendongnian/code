    public class CustomControl : Control
    {
        ...
        public CustomControl(Button button, Label label)
        {
            ...
            _button.MouseDown += OnMouseDown;
            _label.MouseDown += OnMouseDown;
        }
        override void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                (sender as Control).DoDragDrop(this, DragDropEffects.Move);
        }
    }
