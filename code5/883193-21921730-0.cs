        public class SpecialTaxServiceProvider<T, S> : TaxServiceProvider<T, S>
            where T : SpecialTaxServiceProviderConfig
            where S : SpecialTaxServiceInfo
        {
            public override S GetTax(int zipCode)
            {
                return null;
            }
        }
