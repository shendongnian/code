    try
    {
        string str = doc_cell.Text;
        ulong a = Convert.ToUInt64(str);
    }
    catch (FormatException)
    {
        MessageBox.Show("Error");
    }
