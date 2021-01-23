    private static ClsController controlerLink = null;
        public static ClsController ControlerLink
        {
            get
            {
                if (controlerLink == null)
                {
                    controlerLink = new ClsController();
                }
                return controlerLink;
            }
        }
