        string AppDomainDataDirectory 
        {
            get
            {
                object obj = AppDomain.CurrentDomain.GetData("DataDirectory");
                return obj != null ? obj.ToString() : "";
            }
            set
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", value);
            }
        }  
