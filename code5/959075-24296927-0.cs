        public bool IsDownloaded {get;set;}
        public bool IsPurchased { get; set; }
        [LinkToProperty("IsDownloaded")]
        [LinkToProperty("IsPurchased")]
        public bool IsAvailableToUse
        {
            get
            {
                return IsPurchased && IsDownloaded;
            }
        }
        [LinkToCommand("PurchaseCommand")]
        private void btnPurchase()
        {
        }
        [LinkToCommand("DownloadCommand")]
        private void btnDownload()
        {
        }
