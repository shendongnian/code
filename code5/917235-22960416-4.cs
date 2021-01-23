    private void ClearControls(Control control)
        {
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                ClearControls(control.Controls[i]);
            }
    
            if (!(control is TableCell))
            {
                if (control.GetType().GetProperty("SelectedItem") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    try
                    {
                        literal.Text =
                            (string)control.GetType().GetProperty("SelectedItem").
                                GetValue(control, null);
                    }
                    catch
                    { }
                    control.Parent.Controls.Remove(control);
                }
                else if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text =
                        (string)control.GetType().GetProperty("Text").
                            GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
            }
            return;
        }
