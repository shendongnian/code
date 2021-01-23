    protected void update(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Path.Combine(Request.PhysicalApplicationPath, "App_Data/AM_data.xml"));
        Button myButton = (Button)sender;
    
        foreach (ListViewItem item in LV_data.Items)
        {
            FileUpload FU_small1 = (FileUpload)item.FindControl("FU_small1");
            FileUpload FU_big1 = (FileUpload)item.FindControl("FU_big1");
            if (FU_small1.HasFile && FU_big1.HasFile)
            {
                FileInfo small_info = new FileInfo(FU_small1.FileName);
                FileInfo big_info = new FileInfo(FU_big1.FileName);
                string ext_small = small_info.Extension;
                string ext_big = big_info.Extension;
                string filename_small = Guid.NewGuid().ToString();
                string filename_big = Guid.NewGuid().ToString();
    
    
                int i = Convert.ToInt32(myButton.CommandArgument.ToString());
    
                TextBox TB_title = myButton.FindControl("TB_title") as TextBox;
                string myString3 = TB_title != null ? TB_title.Text : string.Empty;
    
                FU_small1.SaveAs(Path.Combine(Request.PhysicalApplicationPath, "imgs/data/thumbs/" + filename_small + ext_small));
                FU_big1.SaveAs(Path.Combine(Request.PhysicalApplicationPath, "imgs/data/big/" + filename_big + ext_big));
                XmlElement el = (XmlElement)doc.SelectSingleNode("Data/datas/data[id='" + i + "']");
                el.SelectSingleNode("small_image_url").InnerText = "~/imgs/data/thumbs/" + filename_small  + ext_small;
                el.SelectSingleNode("title").InnerText = myString3;
                el.SelectSingleNode("big_image_url").InnerText = "~/imgs/data/big/" + filename_big + ext_big;
    
                doc.Save(Path.Combine(Request.PhysicalApplicationPath, "App_Data/AM_data.xml"));
            }
        }
    
    
        Response.Redirect(Request.RawUrl);
        }
