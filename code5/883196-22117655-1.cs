    // Tier 1 of my class hierarchy
    public abstract class TaxServiceProvider<C, I>
        where C : TaxServiceProviderConfig
        where I : TaxServiceInfo
    {
        protected C Config { get; set; }
        public abstract I GetTax(int zipCode);
    }
    public abstract class TaxServiceInfo {
        public TaxServiceInfo(string param1, string param2, int param3, ect...) {
            ...
        }
    }
    public abstract class TaxServiceProviderConfig { ... }
    // Tier 2 of my class hierarchy
    public class DerivedTaxServiceProvider<C, I> : TaxServiceProvider<C, I>
        where C : DerivedTaxServiceProviderConfig
        where I : DerivedTaxServiceInfo
    {
        protected Func<S, string, string, int, ect...> Factory;
        public DerivedTaxServiceProvider (C config, Func<I, string, string, int, ect...> factory) {
            Config = config;
            Factory = factory;
        }
        public override I GetTax(int zipCode) {
            ...
            I taxServiceInfo = Factory("param1", "param2", 3, ect...);
            ...
            return I;
        }
    }
    public class DerivedTaxServiceInfo : TaxServiceInfo {
        public DerivedTaxServiceInfo(string param1, string param2, int param3, ect...) 
            : base(param1, param2, param3, ect...) 
        { ... }
    }
    public class DerivedTaxServiceProviderConfig : TaxServiceProviderConfig { ... }
    // Tier 3 of my class hierarchy
    public class ConcreteTaxServiceProvider : DerivedTaxServiceProvider<ConcreteTaxServiceProviderConfig, ConcreteTaxServiceInfo> {
        public ConcreteTaxServiceProvider(ConcreteTaxServiceProviderConfig config, Func<ConcreteTaxServiceInfo, string, string, int, ect...> factory) {
            Config = config;
            Factory = factory;
        }
        public override ConcreteTaxServiceInfo GetTax(int zipCode) {
            return base.GetTax(zipCode);
        }
    }
    public class ConcreteTaxServiceInfo : DerivedTaxServiceInfo {
        public ConcreteTaxServiceInfo(string param1, string param2, int param3, ect...) 
            : base(param1, param2, param3, ect...) 
        { ... }
        public static ConcreteTaxServiceInfo CreateConcreteTaxServiceInfo(string param1, string param2, int param3, ect...) {
            return new ConcreteTaxServiceInfo(param1, param2, param3, etc...);
        }
    }
    public class ConcreteTaxServiceProviderConfig : DerivedTaxServiceProviderConfig { ... }
    // Implementation of my class hierarchies
    public void method() {
        ConcreteTaxServiceProviderConfig() config = new ConcreteTaxServiceProviderConfig();
        
        ConcreteTaxServiceProvider provider = new ConcreteTaxServiceProvider(config, ConcreteTaxServiceInfo.CreateConcreteTaxServiceInfo);
        ConcreteTaxServiceInfo serviceInfo = provider.GetTax(99939);
    }
