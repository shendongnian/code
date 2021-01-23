    protected void Button1_Click(object sender, EventArgs e)
    {
           ListBox1.Items.Clear();
           string[] files = Directory.GetFiles(Server.MapPath("~/files"));
           foreach (string item in files)
           {
               string fileName = Path.GetFileName(item);
               if (fileName.ToLower().Contains(TextBox1.Text.ToLower()))
               {
                   ListBox1.Items.Add(fileName);
               }
           }
    }
