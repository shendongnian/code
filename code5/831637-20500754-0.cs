     protected void abc(object sender, ListViewCommandEventArgs e)
        {
            // if(e.CommandSource == System.Web.UI.WebControls.ImageButton)
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            //int RowID = Convert.ToInt32(ListView1.DataKeys[dataItem.DisplayIndex].Value);
            int DispalyIndex = e.Item.DisplayIndex;
            int ItemIndex = e.Item.DataItemIndex;
            ImageButton imgbtn = (ImageButton)dataItem.FindControl("ImageButton1");
            if (imgbtn != null)
            {
                string imageurl = imgbtn.ImageUrl;
                if (imageurl != null && imageurl != string.Empty)
                {
                    int equalindex = imageurl.IndexOf("=");
                    int Totallength = (imageurl.TrimEnd()).TrimStart() .Length;
                    int ImageID = Convert.ToInt32(imageurl.Substring(equalindex + 1, (Totallength -(equalindex+1))));
                }
            }
        }
