        public string[] GetCodes(string prefixText)
        {
          return MyDB.tblCountries.Where(c=>c.CountryCode.
                 StartsWith(prefixText)).OrderBy(c=>c.CountryCode).Select(c=> c.CountryCode + "(" + c.CountryName + ")").ToArray();    
        }
