    foreach (var param in parameters)
        {
            if (param.Key.Equals("BelegId"))
            {
                var belegId = Convert.ToInt32(param.Value);
                query = query.Where(x => x.Beleg.BelegId == belegId);
            }
            if (param.Key == "Name")
            {
                query = query.Where(x => x.Kunde.Name.Contains(param.Value));
            }
            if (param.Key.Equals("Datum"))
            {
                query = query.Where(x => x.Datum.Equals(param.Value));
            }
            if (param.Key.Equals("KundenNr"))
            {
                var kundenNr = Convert.ToInt32(param.Value);
                query = query.Where(x => x.Beleg.KundenNr == kundenNr);
            }
            if (param.Key.Equals("Land"))
            {
                query = query.Where(x => x.Kunde.Land.ZweiBuchstabenIsoCode.Contains(param.Value));
            }
            if (param.Key.Equals("PLZ"))
            {
                query = query.Where(x => x.Kunde.Plz.Contains(param.Value));
            }
            if (param.Key.Equals("Ort"))
            {
                query = query.Where(x => x.Kunde.Ort.Contains(param.Value));
            }
            if (param.Key.Equals("Erfasser"))
            {
                query = query.Where(x => x.Beleg.ErfasstVonUsername.Contains(param.Value));
            }
            if (param.Key.Equals("Kommission"))
            {
                query = query.Where(x => x.Beleg.KopfKommission.Contains(param.Value));
            }
            if (param.Key.Equals("ErstePosition"))
            {
                query = query.Where(x => x.Beleg.ErsteRechnungsPosition.Contains(param.Value));
            }
        }
