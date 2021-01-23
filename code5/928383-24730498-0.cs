    public void splitString(string[] strText)
    {            
        string[] arr = txtEntryField.Lines;
            for (int n = 0; n < arr.Length; n++)
            {
                if (arr[n].Length > 8)
                {
                    arr[n] = arr[n].Substring(0, 8);
                }                                                                     
            }
            txtEntryField.Lines = arr;
            if (txtEntryField.Lines.Length > 0)
            {
                txtEntryField.SelectionStart = txtEntryField.Text.Length;
            }
    }
