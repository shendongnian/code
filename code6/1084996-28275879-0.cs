        private void bt_AddPicture_Click(object sender, EventArgs e)
        {
            //Add image to datagrid view
            //You can add picture from SQL database instead.
            dataGridView1.Rows.Add(Image.FromFile(@"c:\Users\Programmer\Desktop\tmp\tmp\Capture.PNG"));
        }
        private void bt_ShowPicture_Click(object sender, EventArgs e)
        {
            //Show image from datagrid view in picture box.
            //You can use it in event on cellEnter
            pictureBox1.Image = ( dataGridView1.Rows[0].Cells[0].Value as Image);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
