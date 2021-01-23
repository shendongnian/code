      if (e.CommandName.Equals("benglore"))
        {
            rptHotel.DataSource = null;
            rptHotel.DataBind();
            int cityID = 2;
            rptHotel.DataSource = dalMST_Hotel.SelectTop4(cityID, myConnectionString);
            rptHotel.DataBind();
        }
        else if (e.CommandName.Equals("vadodara"))
        {
            rptHotel.DataSource = null;
            rptHotel.DataBind();
            int cityID = 3;
            rptHotel.DataSource = dalMST_Hotel.SelectTop4(cityID, myConnectionString);
            rptHotel.DataBind();
        }
        else if (e.CommandName.Equals("ahmedabad"))
        {
            rptHotel.DataSource = null;
            rptHotel.DataBind();
            int cityID = 1;
            rptHotel.DataSource = dalMST_Hotel.SelectTop4(cityID, myConnectionString);
            rptHotel.DataBind();
        }
        else if (e.CommandName.Equals("surat"))
        {
            rptHotel.DataSource = null;
            rptHotel.DataBind();
            int cityID = 4;
            rptHotel.DataSource = dalMST_Hotel.SelectTop4(cityID, myConnectionString);
            rptHotel.DataBind();
        }
        else if (e.CommandName.Equals("pune"))
        {
            rptHotel.DataSource = null;
            rptHotel.DataBind();
            int cityID = 5;
            rptHotel.DataSource = dalMST_Hotel.SelectTop4(cityID, myConnectionString);
            rptHotel.DataBind();
        }
        else if (e.CommandName.Equals("mumbai"))
        {
            rptHotel.DataSource = null;
            rptHotel.DataBind();
            int cityID = 6;
            rptHotel.DataSource = dalMST_Hotel.SelectTop4(cityID, myConnectionString);
            rptHotel.DataBind();
        }
    
        }
    
    
    }
