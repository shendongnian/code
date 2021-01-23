    var r = xmlDoc.Descendants("EstablishmentDetail")
                  .Select(n => new Restaurant()
                  {
                      FHRSID = (int)n.Element("FHRSID"),
                      BusinessName = n.Element("BusinessName").Value,
                      RatingValue = RValue(n),
                      HygieneScore = HScores(n)
                  })
                  .Single(r => r.FHRSID == id);
