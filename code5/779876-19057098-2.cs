    public class DynamicsLayout : LayoutBase
    {
        public override PaymentMode GetPaymentType(object raw)
        {
            if (raw is string && raw.ToString() == "{3131-3-b;ablabla}")
                return PaymentMode.Cash;
            // others
        }
    }
