    public RegisterModel FillModel()
    {
        return new RegisterModel
                {
                    TitleList = new SelectList(DataAccess.DAL.DropDownValues("Title"), "Value", "Text"),
                    BankList = new SelectList(DataAccess.DAL.DropDownValues("Bank"), "Value", "Text")
                };
    }
