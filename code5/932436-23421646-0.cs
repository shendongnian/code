    private void BindCountry()
        {
                DataTable dt = new DataTable();
                dt = objUser.SelAllCountry();
                objCommon.BindDropDown(ddlCountry, "CountryID", "CountryName", dt);
        }
