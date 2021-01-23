    string prevVal = null;
    private void txtSel_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(prevVal == null)
        {
            prevVal = txtSel.Text;
        }
        else
        {
            for(int i = 0; i < txtSel.Text.length; i++)
            {
                if(txtSel.Text.Substring(i, 1) != prevVal.Substring(i, 1))
                {
                    txtSel.SelectionStart = i+1;
                    break;
                }
            }
        }
    }
