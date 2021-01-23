    void textBoxSample_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsPunctuation(e.KeyChar) ||  
                          Char.IsSeparator(e.KeyChar) || 
                          Char.IsSymbol(e.KeyChar);
        }
