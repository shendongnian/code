    if (!Char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
     {
                        e.Handled = true;
                        base.OnKeyPress(e);
     }
