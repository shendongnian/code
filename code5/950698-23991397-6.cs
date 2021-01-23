    private void ass_wijzig_Load(object sender, EventArgs e)
             {
                    string query = "Select Image From Product where productid = 1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    // MySqlDataReader reader = cmd.ExecuteReader();
                    var da = new MySqlDataAdapter(cmd);
                    var ds = new DataSet();
                    da.Fill(ds, "Image");
                    int count = ds.Tables["Image"].Rows.Count;
             
                    for (int i = 0; i < count-1; i++)
                    {                
                        var data = (Byte[])(ds.Tables["Image"].Rows[i]["Image"]);
                        var stream = new MemoryStream(data);
                        PictureBox pbList = new PictureBox();               
                        pbList.Name = "pic" + i;
                        pbList.Size = new Size(300, 75);
                        pbList.Image = Image.FromStream(stream);
                        myform.Controls.Add(pbList);
                    } 
              }
