    public String buildWOEIDQuery(List<string> searchCriteria)
    {
      String query = "http://where.yahooapis.com/v1/places.q('";
      for (int i = 0; i < searchCriteria.Count; i++ )
      {
         query += searchCriteria[i];        
      }
       query = query.TrimEnd(',');
       query += "')?appid=" + devKey;
       return query;
    }
