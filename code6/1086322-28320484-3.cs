    var suppliers = SupplierView.Select()
            .GroupBy(x => x.Name.Substring(0, 1).ToUpper(),
                (alphanumeric, suppliers) => new AlphanumericSuppliers // concrete
                {
                    Alphanumeric = alphanumeric,
                    Suppliers = suppliers.OrderBy(x => x.Name).ToList() // *
                })
            .OrderBy(x => x.Alphanumeric);
