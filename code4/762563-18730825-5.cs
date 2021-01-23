    public class ReplaceWarrantyProcess : WarrantyProcessTemplate
    {
        protected override void GenerateWarrantyTransactionFor(WarrantyRequest warrantyRequest)
        {
            // Code to generate replacement order
        }
        protected override void CalculateRefundFor(WarrantyRequest warrantyRequest)
        {
            WarrantyRequest.AmountToRefund = warrantyRequest.PostageCost;
        }
    }
    public static class WarrantyProcessFactory
    {
        public static WarrantyProcessTemplate CreateFrom(WarrantyAction warrantyAction)
        {
            switch (warrantyAction)
            {
                case (WarrantyAction.RefundProduct):
                    return new RefundWarrantyProcess();
                case (WarrantyAction.ReplaceProduct):
                    return new ReplaceWarrantyProcess();
                default:
                    throw new ApplicationException(
                         "No Process Template defined for Warranty Action of " +
                                                   warrantyAction.ToString());
            }
        }
    }
