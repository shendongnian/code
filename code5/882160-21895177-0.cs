    for (int i2 = dataGridView1.Rows.Count - 1; i2 >= 0; i2--)
    {
        //Don't name a singular item with a plural name -- rows should be row
        DataGridViewRow row = dataGridView1.Rows[i2];
        //MetaWeblogClient implements IDisposable so we can wrap it in a using statement
        using (MetaWeblogClient blogClient = new MetaWeblogClient())
        {
            //You do not need the parenthesis around the values
            blogClient.NewPost(row.Cells["imageurl"].Value.ToString(),
                               row.Cells["title"].Value.ToString(), 
                               row.Cells["videourl"].Value.ToString());
            row.Cells["done"].Value = "yes";
        }
        //blogClient is automatically disposed of here because of the using statement
    }
