    public static class HelperTables
    {
       private static Lazy<List<ICountry>> _countries;
       static HelperTables //Static constructor
       {
           //Instantiating the lazy object in the static constructor will prevent race conditions
          _countries = new Lazy<List<ICountry>>(() =>
          {
            List<ICountry> result = new List<ICountry>();
            DataTable dtCountries = SqlHelper.ExecuteDataTable("stp_Data_Countries_Get");
            foreach (DataRow dr in dtCountries.Rows)
            {
                result.Add(new Country
                {
                    ID = Convert.ToInt32(dr["CountryId"]),
                    Name = dr["Name"].ToString()
                });
            }
            return result;
          });
       }
       public static List<ICountry> GetAllCountries()
       {
          return _countries.Value;
       }
    }
