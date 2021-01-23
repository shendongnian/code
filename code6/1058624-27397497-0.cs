    protected void Image1_Click(object sender, ImageClickEventArgs e) 
    {
        String val = DropDown.SelectedItem.Value;
        Btn_1.ImageUrl = "~/Images/" + val + ".png";
        Btn_1.PostBackUrl = "http://www." + val + ".com";
        Btn_1.OnClientClick = "";
    }
