    protected void Page_Load(object sender, EventArgs e)
        {
            string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/Path/Relative/To/Root.jpg"));
            int i = 1;
            foreach (string s in filesindirectory)
            {
                s.Split();
                Image img = new Image();
                img.ID = "image" + i.ToString();
                Response.Write(s.ToString()+"</br>");
                string fileName = Path.GetFileName(s.ToString());
                img.ImageUrl = "~/images/"+fileName;
                img.Visible = true;
                Page.Controls.Add(img);
                i++;
            }
        }
