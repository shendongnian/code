    private void list_img_SelectedIndexChanged(object sender, EventArgs e)
    {
        var item = list_img.SelectedItems.FirstOrDefault();
        if (item != null)
        {
            var img = item.ImageList.Images[item.ImageIndex];
            var f = new Form2();
            f.pictureBox1.Image = img;
            MessageBox.Show("pause");
            f.Show();
        }
    }
