        protected D DataContext
        {
            get
            {
                if (dataContext == null)
                {
                    dataContext = new D();
                    dataContext.Database.Connection.ConnectionString = "the new connectionstring";
                }
                return dataContext;
            }
            set { dataContext = value; }
        }
