        protected void shoeRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            FixbayDBDataContext db = new FixbayDBDataContext();
            var colors = from c in db.ColorTbls select new { ColorID = c.ColorID, ColorName = c.ColorName, };
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ddl = (DropDownList)e.Item.FindControl("colorList1");
                ddl.DataSource = colors;//Or any other datasource.
                ddl.DataTextField = "ColorName";
                ddl.DataValueField = "ColorName";
                ddl.DataBind();
            }
        }
