            try
            {
                return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];`
            }
            catch (Exception ce)
            {
                throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
            }
        }
