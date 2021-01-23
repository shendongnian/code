		DAL.DataAccess Dal = new DAL.DataAccess();
		dynamic obj = new LookUpCollection();
		obj = Dal.GetLookupByCategoryID(iCategoryID, LookUpGroup);
		if (obj.Count > 0) {
			ddl.SelectedIndex = -1;
			ddl.DataSource = obj;
			ddl.DataValueField = "Value";
			ddl.DataTextField = "Description";
			ddl.DataBind();
			switch (DefaultValue) {
				case DropDownComboDefault.DefaultValueNone:
					break;
				case DropDownComboDefault.DefaultValueEmpty:
					ddl.Items.Insert(0, "");
					ddl.SelectedIndex = 0;
					break;
				case DropDownComboDefault.DefaultValueSelect:
					ddl.Items.Insert(0, "--Select--");
					ddl.SelectedIndex = 0;
					break;
			}
		}
	
}
