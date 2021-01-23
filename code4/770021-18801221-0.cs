            ObjectFactory.Initialize(conf =>
            {
                conf.For<IPricingFactorsRepository>().Use<PricingFactorsRepository>();
                conf.For<PricingHandler>().Use<PricingHandler>().Named("Default");
                conf.For<PricingHandler>().Add<PricingHandler>().Named("Overriding")
                    .Ctor<IPricingFactorsRepository>().Is<OverridePricingFactorsRepository>();
            });
