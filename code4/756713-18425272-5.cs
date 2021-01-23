    var modelBuilder = new DbModelBuilder();
    var modelConfiguration = new ModelConfigurator(modelBuilder);
    modelConfiguration.Entity<Product>().Has(e => e.Property(en => en.Name).IsRequired())
                                        .Has(e => e.Property(en => en.UPC).IsRequired())
    									.Has(e => e.Property(en => en.Price).IsRequired())
    									.Has(e => e.Property(en => en.Description).IsRequired());
    // continue configuring properties, and creating methods on ModelConfigurator as needed
