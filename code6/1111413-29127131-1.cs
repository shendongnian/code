    private void Button1_Click(object sender, EventArgs e)
        {
            string path = this.textBoxForPath.Text;
            
            if (File.Exists(path))
            {
                // Do Something
            }
        }
