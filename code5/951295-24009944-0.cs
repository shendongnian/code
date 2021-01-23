    int nextImageNumber = 1;
    private void button5_Click(object sender, EventArgs e)
    {         
        var listViewItem = listView2.Items.Add(label1.Text);
    
        Bitmap bm = new Bitmap(panel3.Size.Width, panel3.Size.Height);
        panel3.Refresh();
        panel3.DrawToBitmap(bm, new Rectangle(0, 0, panel3.Size.Width, panel3.Size.Height));
        string name = nextImageNumber.ToString();
        imageList1.Images.Add(name, bm);
        listViewItem.ImageKey = name;
        nextImageNumber++;           
    }
