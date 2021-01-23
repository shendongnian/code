        public DateTime? _PurchaseDate{get;set;}
        public string _StrPurchaseDate
        {
            get
            {
                if (_PurchaseDate != null)
                {
                    return ((DateTime)_PurchaseDate).ToString("dd-MM-yyyy");
                }
                else
                {
                    return "";
                }
            }
            set
            {
            }
        }
