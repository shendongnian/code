             if (Session["totalCost"] != "confirm")
             {
                totRevenueLabel.Text = totalRevenueInteger.ToString();
                string value = Session["totalCost"].ToString();
                         
                totalRevenueInteger += !string.IsNullOrEmpty(value) ? int.TryParse(value) : 0;
             }
