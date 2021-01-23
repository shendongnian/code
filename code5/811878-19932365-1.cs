    if(PlaceHolder1 != null)
    {
        case "Fire":
            var uc = LoadControl("~/controls/Fire.ascx");
        
            if(uc != null)
            {
                PlaceHolder1.Controls.Add(uc);
            }
            else
            {
                // Do something here to alert user that control did not load
                // LabelError.Text = "Unable to load Fire user control.";
            }
            break;
    }
