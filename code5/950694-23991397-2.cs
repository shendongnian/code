    private void ass_wijzig_Load(object sender, EventArgs e)
     {
            string query = "Select Image From Product where productid = 1";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            // MySqlDataReader reader = cmd.ExecuteReader();
            var da = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds, "Image");
            int count = ds.Tables["Image"].Rows.Count;
            PictureBox[] pics = new PictureBox[count];
     
            for (int i = 0; i < count-1; i++)
            {                
                var data = (Byte[])(ds.Tables["Image"].Rows[i]["Image"]);
                var stream = new MemoryStream(data);
                pics[i] = new PictureBox();               
                pics[i].Name = "pic" + i;
                pics[i].Size = new Size(300, 75);
                pics[i].Image = Image.FromStream(stream);
                myform.Controls.Add(pics[i]);
            } 
      }
