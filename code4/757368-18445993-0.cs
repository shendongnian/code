    public enum BachEnum 
    {
        Beach,
        Bush
    }
    Session["bach"] = (bachRadioButtonList.SelectedValue == "Beach bach") ? BachEnum.Beach : BachEnum.Beach;
