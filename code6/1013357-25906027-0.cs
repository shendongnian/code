    protected void Button1_Click(object sender, EventArgs e)
    {
           ListBox1.Items.Clear();
           DirectoryInfo di =
               new DirectoryInfo(Server.MapPath("~/files"));
           FileInfo[] files =
               di.GetFiles("*", SearchOption.AllDirectories);
           foreach (FileInfo item in files)
           {
               string fileName = item.Name;
               if (fileName.ToLower().Contains(TextBox1.Text.ToLower()))
               {
                   ListBox1.Items.Add(fileName);
               }
           }
    }
