    public IHttpActionResult testloadpart(FulfillRequisitionRequest incoming) {
    //do stuff
    //incoming.update does not exist.
    //incoming.NumberOfItems does not exist.
    //incoming.RequisitionId DOES exist
    
    }
	public partial class FulfillRequisitionRequest {
		[XmlElementAttribute(Order = 0)]
		public long RequisitionId { get; set; }
		[XmlArrayAttribute(Order = 1)]
		[XmlArrayItemAttribute("FulfillItem", IsNullable = false)]
		public List<fulfillItem> FulfillItemList { get; set; }
		public FulfillRequisitionRequest() {
			FulfillItemList = new List<fulfillItem>();
		}
	}
