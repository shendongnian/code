    private void ass_wijzig_Load(object sender, EventArgs e)
    {
            string query = "Select Image From Product where productid = 1";
    
           MySqlDataAdapter adpt=new MySqlDataAdapter(query,connection);
           DataTable dt=new DataTable();
           adpt.Fill(dt);
         if(dt.Rows.Count>0)
         {
          PictureBox pcb[]=new PictureBox[dt.rows.count];
           for(int i=0;i<dt.Rows.Count;i++)
           {
                var data = (Byte[])(dt.Rows[i]["Image"].ToString());
                var stream = new MemoryStream(data);
                pcb[i].Image = Image.FromStream(stream);
           }
    
         }
    }
     
