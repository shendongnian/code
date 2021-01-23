        public class UserData
        {
            public string Name;
            public string Description;
        }
        public UserData[] GetCountryAndManufacturerForUser(int userId)
        {
            var array = (from xx in _er.UserRoles
                         join xy in _er.Countries on xx.CountryId equals xy.Id
                         join xz in _er.Manufacturers on xx.ManufacturerId equals xz.Id
                         where xx.UserId == userId
                         select new UserData() { xy.Name, xz.Description }).ToArray();
            return array;
        }
