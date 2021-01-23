     Point startPoint;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void tbxExpression_Dragging(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Button"))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }
        private void tbxExpression_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Button"))
            {
                // Get the dragged data and place it in textbox.
                var content = (Button)e.Data.GetData("Button");
                TextBox tbx = (TextBox)sender;
                tbx.Text = content.Content.ToString();
            }
        }
        // Button Events for Dragging.
        private void button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null); // Absolute position.
        }
        private void button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDragging(startPoint, e))
            {
                // Get the dragged button
                Button btn = (Button)sender;
                if (btn != null)
                {
                    // Initialize the drag and drop.
                    DataObject dragData = new DataObject("Button", btn);
                    DragDrop.DoDragDrop(btn, dragData, DragDropEffects.Copy);
                    e.Handled = true;
                }
            }
        }
        // Helper
        private static bool IsDragging(Point dragStart, MouseEventArgs e)
        {
            Vector diff = e.GetPosition(null) - dragStart;
            return e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance);
        }
