        public List<string> Permission
        {
            get { return lstGivenPermissions.Items.Cast<string>().ToList(); } //
            set { lstGivenPermissions.DataSource = value; }
        }
