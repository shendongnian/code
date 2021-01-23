    string str = ImageList1.SelectedItem.Text; 
    ImageFromList.ImageUrl = "~/Content/Images/SubDir/" + str;
    ImageFromList.CssClass = "yourCssClass"; // yourCssClass = your class with width and height
    ImageFromList.ResolveUrl("~/Content/Images/SubDir/" + str);
    ImageFromList.NavigateUrl = "/Content/Images/SubDir/" + str;
