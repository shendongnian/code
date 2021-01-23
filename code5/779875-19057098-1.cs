    public class Layout1 : LayoutBase
    {
        public override PaymentMode GetPaymentType(int key)
        {
            switch (key)
            {
                case 1:
                    return PaymentMode.Visa;
                // others...
            }
        }
    }
    public class Layout2 : LayoutBase
    {
        public override PaymentMode GetPaymentType(int key)
        {
            switch (key)
            {
                case 1:
                    return PaymentMode.MasterCard;
                // others...
            }
        }
    }
