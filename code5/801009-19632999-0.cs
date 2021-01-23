    int num_row = Convert.ToInt16(sometable.Rows.Count);
    for (int i = 1; i < num_row; i++)
    {
        string txtID="txt" + i.Tostring();
        TextBox txt= (TextBox)FindControl(txtID);
        string txtValue=txt.Text;
    }
