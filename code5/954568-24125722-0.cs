        public List<string>  GivenPermission
        {
            get { return lstGivenPermissions.Items.Cast<string>().ToList(); }
            set { lstGivenPermissions.DataSource = value; }
        }
