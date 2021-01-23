    else
        { 
            Counter++;
            litems = objContext.ContentCountries.Where(x => ContentID.Contains(x.ContentID) && x.CountryID == CountryID).Select(x => new System.Web.UI.WebControls.ListItem { Text = x.Text, Value = Counter.ToString() }).ToList();
        }
