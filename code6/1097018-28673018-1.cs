    (FindControl(
        "elective" + System.Text.RegularExpressions.Regex.Match(
            lb.ID, 
            @"(\d+)(?!.*\d)").ToString()) 
        as System.Web.UI.WebControls.WebControl)
    .Enabled = true;
