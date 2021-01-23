    namespace MyTypes
    {
        [DataContract]
        public class PurchaseOrder
        {
            private int poId_value;
    
            // Apply the DataMemberAttribute to the property.
            [DataMember]
            public int PurchaseOrderId
            {
    
                get { return poId_value; }
                set { poId_value = value; }
            }
        }
    }
