    private void tbxExpression_PreviewDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(string)))
        {
            // Get the dragged data and place it in textbox.
            string content = e.Data.GetData(typeof(string)).ToString();
            Debug.WriteLine("PreviewDrop");
            TextBox tbx = (TextBox)sender;
            tbx.Text = content;
            e.Handled=true;
        }
    }
