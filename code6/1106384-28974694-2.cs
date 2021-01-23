    private void ListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
    	byte[] arrayImage = Convert.ToByte(this.DataSet11.Tables[0].Rows[this.ListBox1.SelectedIndex]["ITEM_Picture"]);
    	MemoryStream ms = new MemoryStream(arrayImage);
    	var img = this.PictureBox1;
    	img.Image = Image.FromStream(ms);
    	img.SizeMode = PictureBoxSizeMode.CenterImage;
    }
