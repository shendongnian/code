               if (!String.IsNullOrEmpty(searchString))
            {
                Supplys = Supplys.Where(s => s.CompanyName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(ChainSupplier))
            {
                Supplys = Supplys.Where(x => x.Supplier == ChainSupplier);
            }
            if (!String.IsNullOrEmpty(city))
            
            {
                return View(Supplys.Where(x => x.SUP_City.Name == city));
            }
            return View(Supplys);
        }
