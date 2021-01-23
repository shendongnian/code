    HtmlGenericControl divContainer = new HtmlGenericControl("div");
    
                HtmlGenericControl nameDiv = new HtmlGenericControl("div");
                // Not sure why you concatenate Name and Status here. I'll just use one value per each row
                // status += dr["Status"].ToString();
                // name += dr["name"].ToString();
                nameDiv.InnerText = dr["name"].ToString();
                nameDiv.Style.Add("float", "left");
                divContainer.Controls.Add(nameDiv);
    
                HtmlGenericControl statusDiv = new HtmlGenericControl("div");
                statusDiv.InnerText = dr["Status"].ToString();
                statusDiv.Style.Add("float", "left");
                divContainer.Controls.Add(statusDiv);
    
                container.Controls.Add(div);
