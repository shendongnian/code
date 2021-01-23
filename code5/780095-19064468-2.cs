    protected void Page_PreRender(object sender, EventArgs e)
            {
                string currentImage = RouteData.Values["Name"].ToString();
                if (!String.IsNullOrEmpty(currentImage))
                {
                    Images image = Global.col.Find(x => x.CurrentImage == currentImage);
                    // Get Current Image URL where actually it is stored using from image variable and render / set image path where you want to using image.CurrentImagePhysicalName 
    
    
                    // Set Next - Previous Image urls
                    if (!String.IsNullOrEmpty(image.NextImage))
                    {
                        hyperlink_next.Visible = true;
                        hyperlink_next.Text = image.NextImage;
                        hyperlink_next.NavigateUrl = GetRouteUrl("RouteForImage", new { Name = image.NextImage });                    
                    }
                    else
                        hyperlink_next.Visible = false;
    
                    if (!String.IsNullOrEmpty(image.PreviousImage))
                    {
                        hyperlink_previous.Visible = true;
                        hyperlink_previous.Text = image.PreviousImage;
                        hyperlink_previous.NavigateUrl = GetRouteUrl("RouteForImage", new { Name = image.PreviousImage });
                    }
                    else
                        hyperlink_previous.Visible = false;
                }
            }
