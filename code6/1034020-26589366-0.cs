    public static IEnumerable<Restaurant> GetData ( )
    {
      XDocument xmlDoc = XDocument.Load("http://ratings.food.gov.uk/OpenDataFiles%5CFHRS501en-GB.xml");
      foreach (var xml in xmlDoc.Descendants("EstablishmentDetail"))
      {
        var eFHRSID = xml.Element("FHRSID");
        var eBusinessName = xml.Element("BusinessName");
        var eRatingValue = xml.Element("RatingValue");
        var eHygieneScore = xml.Element("Scores").Element("Hygiene");
        if (eFHRSID != null && eBusinessName != null && eRatingValue != null && eHygieneScore != null)
        {
          yield return new Restaurant
          {
            FHRSID = (int)eFHRSID,
            BusinessName = (string)eBusinessName,
            RatingValue = (int)eRatingValue,
            HygieneScore = (int)eHygieneScore,
          };
        }
      }
    }
