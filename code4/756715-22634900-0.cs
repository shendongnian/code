    modelConfiguration.Entity<Product>(e => {
                                       e.Property(en => en.Name).IsRequired();
                                       e.Property(en => en.UPC).IsRequired();
                                       e.Property(en => en.Price).IsRequired();
                                       e.Property(en => en.Description).IsRequired();}
                                      );
