    private string GetFormText()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Control control in this.Controls)
        {
            if (control.GetType() == typeof (TextBox) ||
                control.GetType() == typeof (ComboBox) ||
                control.GetType() == typeof (Label))
            {
                String controlText = String.Format("{0}:{1}", control.Name, control.Text);
                sb.AppendLine(controlText);
            }
        }
        return sb.ToString();
    }
