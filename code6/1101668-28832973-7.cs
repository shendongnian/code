    // the idea is to create an empty gridview with number of rows client selected
    protected void EnterButton_Click(object sender, EventArgs e)
    {
        //in this, 10 has been entered    
        var imageCount = Convert.ToInt32(txtImageCount.Text);
        //var list = new List<string>();
        //for (int i = 0; i < imageCount; i++)
        //{
        //    list.Add(string.Empty);
        //}
        var list = new List<string>(10);
        list.AddRange(Enumerable.Repeat(String.Empty, imageCount));
        ImagesGrid.DataSource = list;
        ImagesGrid.DataBind();
        //TO DO: hide panel1 and make panel2 visible
    }
