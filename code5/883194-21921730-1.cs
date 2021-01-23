        public class A_SpecialTaxServiceProvider : SpecialTaxServiceProvider<A_SpecialTaxServiceProviderConfig, A_SpecialTaxServiceInfo>
        {
            public override A_SpecialTaxServiceInfo GetTax(int zipCode)
            {
                return null;
            }
        }
