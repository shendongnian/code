    bool changing = false; // variable in class-scope
    private void txtMot_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (changing == false)
        {
            try
            {
                changing = true;
                String str = new String('_', motRechercher.Length);
                txtMot.Text = str;
            }
            finally
            {
                changing = false;
            }
        }
    }
