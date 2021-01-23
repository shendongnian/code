     protected void Button2_Click(object sender, EventArgs e)
        {
            int nGridRowCount = GridView1.Rows.Count;
            string[] filenames = new string[nGridRowCount];
            int index=0;
            for (int nSelect = 0; nSelect < nGridRowCount; nSelect++)
            {
                GridViewRow row = GridView1.Rows[nSelect];
            if (((CheckBox)(row.Cells[0].Controls[1])).Checked)
            {
                filenames[index]=GridView1.DataKeys[nSelect]["Text"].ToString();
                index++;
            }
        }
        // Here will come the code to traverse
        // the filenames array and delete the files using file names stored in it
    }
