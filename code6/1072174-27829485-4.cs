    public static void StopUpperAndSpace(TextBox txtBox) 
    {
        txtBox.Text = txtBox.Text.Trim();
        // Set it to lowercase
        txtBox.Text = txtBox.Text.ToLower();
    }
    public static string ToLowerAndTrim(string text)
    {
        return text.Trim().ToLower();
    }
