    protected void update(object sender, EventArgs e)
    {
        //Get xml file 
        XmlDocument doc = new XmlDocument();
        doc.Load(Path.Combine(Request.PhysicalApplicationPath, "App_Data/AM_data.xml"));
        //Set button for index it later by CommandArgument
        Button myButton = (Button)sender;
    
        foreach (ListViewItem item in LV_data.Items)
        {
            //Findcontrol of 2 fileupload on listview
            FileUpload FU_small1 = (FileUpload)item.FindControl("FU_small1");
            FileUpload FU_big1 = (FileUpload)item.FindControl("FU_big1");
            
            //Check if are has file.
            if (FU_small1.HasFile && FU_big1.HasFile)
            {
                //Get extension and genereate random filenames (for avoid ovveride)
                FileInfo small_info = new FileInfo(FU_small1.FileName);
                FileInfo big_info = new FileInfo(FU_big1.FileName);
                string ext_small = small_info.Extension;
                string ext_big = big_info.Extension;
                string filename_small = Guid.NewGuid().ToString();
                string filename_big = Guid.NewGuid().ToString();
    
                //Set i value by button CommandArgument (look on aspx on question)
                int i = Convert.ToInt32(myButton.CommandArgument.ToString());
                //Get title from TextBox and set string from it
                TextBox TB_title = myButton.FindControl("TB_title") as TextBox;
                string myString3 = TB_title != null ? TB_title.Text : string.Empty;
                
                //Save the files from the fileuploads we found, and write it on xml
                FU_small1.SaveAs(Path.Combine(Request.PhysicalApplicationPath, "imgs/data/thumbs/" + filename_small + ext_small));
                FU_big1.SaveAs(Path.Combine(Request.PhysicalApplicationPath, "imgs/data/big/" + filename_big + ext_big));
                XmlElement el = (XmlElement)doc.SelectSingleNode("Data/datas/data[id='" + i + "']");
                el.SelectSingleNode("small_image_url").InnerText = "~/imgs/data/thumbs/" + filename_small  + ext_small;
                el.SelectSingleNode("title").InnerText = myString3;
                el.SelectSingleNode("big_image_url").InnerText = "~/imgs/data/big/" + filename_big + ext_big;
    
                doc.Save(Path.Combine(Request.PhysicalApplicationPath, "App_Data/AM_data.xml"));
            }
        }
    
        // Refresh the page
        Response.Redirect(Request.RawUrl);
        }
