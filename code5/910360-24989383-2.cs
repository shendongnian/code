        private bool isAdmin;
        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = value;
                btnAdmin.Enabled = isAdmin;
            }
        }
