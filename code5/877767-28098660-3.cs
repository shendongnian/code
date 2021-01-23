        public string AltGetSelectedValueString()
        {
            MetaForeignKeyColumn column = (MetaForeignKeyColumn)Column;
            foreach (string foreignKeyName in column.ForeignKeyNames)
                return Misc.ChangeType<string>(DataBinder.GetPropertyValue(Row, foreignKeyName));
            return null;
        }
    
        protected override void OnDataBinding(EventArgs e) {
            base.OnDataBinding(e);
    
            string selectedValueString = AltGetSelectedValueString();
            ListItem item = DropDownList1.Items.FindByValue(selectedValueString);
            if (item != null) {
                DropDownList1.SelectedValue = selectedValueString;
            }
        
        }
    
