    public class RefundWarrantyProcess : WarrantyProcessTemplate
    {
        protected override void GenerateWarrantyTransactionFor(WarrantyRequest warrantyRequest)
        {
            // Code to determine terms of the warranty and devalutionAmt...
        }
        protected override void CalculateRefundFor(WarrantyRequest warrantyRequest)
        {
            WarrantyRequest.AmountToRefund = warrantyRequest.PricePaid * devalutionAmt;
        }
    }
