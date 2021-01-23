    private void button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Debug.WriteLine("Down");
        startPoint = e.GetPosition(null); // Absolute position.
        e.Handled = true;
    }
    private void tbxExpression_PreviewDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(string)))
        {
            // Get the dragged data and place it in textbox.
            string content = e.Data.GetData(typeof(string)).ToString();
            Debug.WriteLine("PreviewDrop: " + String.Join(",",e.Data.GetFormats()));
            TextBox tbx = (TextBox)sender;
            tbx.AppendText(content);
            e.Handled=true;
        }
    }
