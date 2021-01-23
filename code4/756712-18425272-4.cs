    // First option - like this better because it has less cruft than multiple Has invocations
    var modelBuilder = new DbModelBuilder();
    var modelConfiguration = new ModelConfigurator(modelBuilder);
    
    modelConfiguration.Entity<Product>().Has(e => {
     										 e.Property(en => en.Name).IsRequired();
     										 e.Property(en => en.UPC).IsRequired();
    										 e.Property(en => en.Price).IsRequired();
    										 e.Property(en => en.Description).IsRequired();}
    										);           
