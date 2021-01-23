    protected void update(object sender, EventArgs e)
    {
        int index = 0;
        XmlDocument doc = new XmlDocument();
        doc.Load(Path.Combine(Request.PhysicalApplicationPath, "App_Data/AM_data.xml"));
        Button myButton = (Button)sender;
        ListViewItem lvwItem = (ListViewItem)myButton.NamingContainer;
    
        FileUpload FU_small1 = myButton.FindControl("FU_small") as FileUpload;
    
        if (FU_small1 != null && int.TryParse(myButton.CommandArgument, out index))
        {
            string extenstion_small = System.IO.Path.GetExtension(FU_small1.FileName);
            filename_small = Guid.NewGuid().ToString();
    
            TextBox TB_title =  myButton.FindControl("TB_title") as TextBox;
            string myString3 = TB_title!= null ? TB_title.Text : string.Empty;
    
            if (FU_small1.HasFile == true)
            {
                FU_small1.SaveAs(Server.MapPath("~/imgs/data/small/" + filename_small + extenstion_small));
            }
            XmlElement el = (XmlElement)doc.SelectSingleNode("Data/datas/data[id='" + index + "']");
            el.SelectSingleNode("small_image_url").InnerText = "~/imgs/data/small/" + filename_small + extenstion_small;
            el.SelectSingleNode("title").InnerText = myString3;
            el.SelectSingleNode("big_image_url").InnerText = "~/imgs/data/big/" + filename_big + extenstion_big;
    
            doc.Save(Path.Combine(Request.PhysicalApplicationPath, "App_Data/AM_data.xml"));
        }
    
        Response.Redirect(Request.RawUrl);
    }
