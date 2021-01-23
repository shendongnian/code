	private void ViewSentMailDet_Load(object sender, EventArgs e)
	{
		picturebox.Visible = false;
		string con_string = @"Data Source=(local);Initial Catalog=fyp;Integrated Security=true";
		SqlConnection con = new SqlConnection(con_string);
		string qry = "select file from sentmail where msg_id='"+id of a particular row+"' and file is not null";
		SqlDataAdapter ad = new SqlDataAdapter(qry, con);
		DataTable dt = new DataTable();
		ad.Fill(dt);
		foreach (DataRow dr in dt.Rows)
		{
			using (var ms = new MemoryStream((byte[])dr["file"])) 
				picturebox.Image = Image.FromStream(ms);
			picturebox.Visible = true;
		}
	}
