    using (var db = new DMIDataContext())
        {LotInformation newLot = new LotInformation();
                newLot.Id = lot.Id;
                newLot.lot_number = lot.lot_number;
                newLot.exp_date = lot.exp_date;
          foreach (Components comp in lot.Components)
                {
                           newLot.Components.Add(comp);
                 }
          foreach (Families fam in lot.Families)
                {
                           newLot.Families.Add(fam);
                 }
                 db.LotInformation.Add(newLot);
                 db.SaveChanges();
