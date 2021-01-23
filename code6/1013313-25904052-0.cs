    protected void Button1_Click(object sender, EventArgs e)
    {
         string[] files = Directory.GetFiles(Server.MapPath("~/files"))
                       .Where(file => file.ToLower().Contains(TextBox1.Text.ToLower().Trim()))
                       .ToArray();
    
         foreach (string item in files)
         {
            ListBox1.Items.Add(fileName);
         }
    
    }
