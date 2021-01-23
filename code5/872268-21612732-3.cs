    public partial class GetListResponserDetailsOrder
    {
        private string priceTypeField;
        private List<GetListResponseDetailsItemDetails> ItemDetailsField;
        public List<GetListResponseDetailsItemDetails> ItemDetails
        {
            get
            {
                return this.ItemDetailsField;
            }
            set
            {
                this.ItemDetailsField = value;
            }
        }
    }
