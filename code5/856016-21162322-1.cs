    private void ClearTextBoxes(ControlCollection controls)
    {
        foreach (Control c in collection)
        {
            if (c.HasChildren)
            {
                ClearTextBoxes(c.Controls);
                continue;
            }
    
            TextBox tb = c as TextBox; // or TextBoxBase
            if (tb != null)
                tb.Clear();
        }
    }
