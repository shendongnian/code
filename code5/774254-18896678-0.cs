        public class UserData
        {
            public string Name;
            public string Description;
        }
        public List<UserData> GetCountryAndManufacturerForUser(int userId) {
            List<UserData> userdatas = new List<UserData>;
            userdatas = (from xx in _er.UserRoles
                    join xy in _er.Countries on xx.CountryId equals xy.Id
                    join xz in _er.Manufacturers on xx.ManufacturerId equals xz.Id
                    where xx.UserId == userId
                    select new { 
                    Name = xy.Name, 
                    Description = xz.Description 
                    }).ToList();   
            return userdatas ;
        }
