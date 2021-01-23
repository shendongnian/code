    if (parameters.ContainsKey("BelegId"))
                    {
                        var belegId = Convert.ToInt32(parameters["BelegId"]);
                        query = query.Where(x => x.BelegId == belegId);
                    }
                    if (parameters.ContainsKey("Name"))
                    {
                        var tmp = parameters["Name"];
                        query = query.Where(x => x.Name.Contains(tmp));
                    }
                    if (parameters.ContainsKey("Datum"))
                    {
                        var tmp = parameters["Name"];
                        query = query.Where(x => x.BelegDatum.Equals(tmp));
                    }
                    if (parameters.ContainsKey("KundenNr"))
                    {
                        var kundenNr = Convert.ToInt32(parameters["KundenNr"]);
                        query = query.Where(x => x.KundenNr == kundenNr);
                    }
                    if (parameters.ContainsKey("Land"))
                    {
                        var tmp = parameters["Land"];
                        query = query.Where(x => x.Land.ZweiBuchstabenIsoCode.Contains(tmp));
                    }
                    if (parameters.ContainsKey("PLZ"))
                    {
                        var tmp = parameters["PLZ"];
                        query = query.Where(x => x.Plz.Contains(tmp));
                    }
                    if (parameters.ContainsKey("Ort"))
                    {
                        var tmp = parameters["Ort"];
                        query = query.Where(x => x.Ort.Contains(tmp));
                    }
                    if (parameters.ContainsKey("Erfasser"))
                    {
                        var tmp = parameters["Erfasser"];
                        query = query.Where(x => x.ErfasstVonUsername.Contains(tmp));
                    }
                    if (parameters.ContainsKey("Kommission"))
                    {
                        var tmp = parameters["Kommission"];
                        query = query.Where(x => x.KopfKommission.Contains(tmp));
                    }
                    if (parameters.ContainsKey("ErstePosition"))
                    {
                        var tmp = parameters["ErstePosition"];
                        query = query.Where(x => x.ErsteRechnungsPosition.Contains(tmp));
                    }
