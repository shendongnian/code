        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                // Set the initial value if there is one
                string initialValue = AltDefaultValue ?? DefaultValue;
                if (!String.IsNullOrEmpty(initialValue))
                    DropDownList1.SelectedValue = initialValue;
            }
        }
        private string AltDefaultValue
        {
            get
            {
                var foreignKeyNames = Column.ForeignKeyNames;
                if (foreignKeyNames.Count != 1) return null;
                object value;
                if (DefaultValues.TryGetValue(foreignKeyNames.Single(), out value))
                    return Misc.ChangeType<string>(value);
                return null;
            }
        }
