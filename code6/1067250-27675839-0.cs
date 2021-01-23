        public SessionContext USession
        {
            get
            {
                if (base.Session["_USRSESS"] != null)
                    return (BO.SessionContext)base.Session[_USRSESS];
                return null;
            }
            set
            {
                base.Session["_USRSESS"] = value;
            }
        }
