    private void list_img_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (list_img.SelectedItems.Count > 0)
        {
            var item = list_img.SelectedItems[0];
            var img = item.ImageList.Images[item.ImageIndex];
            var f = new Form2();
            f.pictureBox1.Image = img;
            MessageBox.Show("pause");
            f.Show();
        }
    }
