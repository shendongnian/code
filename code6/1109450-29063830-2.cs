    protected void Page_Load(object sender, EventArgs e)
        {
            loadImages();
        }
        string[] files;
        void loadImages()
        {
            files = Directory.GetFiles(Server.MapPath("~/images/"));
            for (int i = 0; i < files.Length; i++)
                ListBox1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(files[i]));
            ListBox1.AutoPostBack = true;
            ListBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            
        }
        void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string extn = files[ListBox1.SelectedIndex];
            extn = extn.Substring(extn.LastIndexOf('.'));
            Image1.ImageUrl = "/images/" + ListBox1.SelectedItem.ToString() + extn;
        }
