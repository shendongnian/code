    public string[,] GetCountryAndManufacturerForUser(int userId)
    {
    
        var array  =(from xx in _er.UserRoles
                         join xy in _er.Countries on xx.CountryId equals xy.Id
                         join xz in _er.Manufacturers on xx.ManufacturerId equals xz.Id
                         where xx.UserId == userId
                         select new string[]{ xy.Name, xz.Description }).ToArray(); 
        return CreateRectangularArray(array);  
 
    }
    static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
    {
        // TODO: Validation and special-casing for arrays.Count == 0
        int minorLength = arrays[0].Length;
        T[,] ret = new T[arrays.Count, minorLength];
        for (int i = 0; i < arrays.Count; i++)
        {
            var array = arrays[i];
            if (array.Length != minorLength)
            {
                throw new ArgumentException
                    ("All arrays must be the same length");
            }
            for (int j = 0; j < minorLength; j++)
            {
                ret[i, j] = array[j];
            }
        }
        return ret;
    }
