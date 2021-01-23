    public static class ControlExtensions
    {    
        public static void SetTextOnMyLabels(this Control control, string text)
        {
            foreach (var label in control.Controls.OfType<Label>())
            {
                 label.Text = text;
             }
         }
    }
    // Use like this in your form
    private void UpdateTextInLabels()
    {
        //Update all labels in panel1
        panel1.SetTextOnMyLabels("SomeText");
    }
