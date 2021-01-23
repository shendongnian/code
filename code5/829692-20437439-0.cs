    public void editForm(DataGridView dg)
    {
        TextBox[] textBoxes = new TextBox[dg.Columns.Count];
        for(int i = 0; i <= dg.Columns.Count-1; i++)
        {
            textBoxes[i] = new TextBox();  
        }
    }
