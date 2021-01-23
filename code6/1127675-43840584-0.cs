    protected void btnSave_Click(object sender, EventArgs e)
        {
            string selectedItem=string.Empty;
            if (ListBox1.Items.Count > 0)
            {
                for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox1.Items[i].Selected)
                    {
                        selectedItem += ListBox1.Items[i].Text.ToString() + ", ";
                        //insert command
                    }
                }
            }
        }
