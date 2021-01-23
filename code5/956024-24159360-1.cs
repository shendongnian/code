    private void tofile_Click(object sender, EventArgs e)
    {
        string file = "database.txt";
        StreamWriter filewrite;
        filewrite = new StreamWriter(file);
        int rcount = DB.Rows.Count;
        for(int i = 0; i < this.DB.Rows.Count - 1; i++)
        {
            foreach (DataGridViewCell item2 in this.DB.Rows[i].Cells)
            {   
                if(item2.Value != null)
                    filewrite.Write(item2.Value.ToString() + " ");
            }
            filewrite.WriteLine("");
        }
        filewrite.Close();
    }
