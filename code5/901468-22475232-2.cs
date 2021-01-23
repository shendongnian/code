    public class Person : ICloneable
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public Address PersonAddress { get; set; }
    
            public object Clone()
            {
                var objResult = new Person();
                objResult.LastName = this.LastName;
                objResult.FirstName = this.FirstName;
                objResult.PersonAddress = new Address();
                objResult.PersonAddress.HouseNumber = this.PersonAddress.HouseNumber;
                objResult.PersonAddress.StreetName = this.PersonAddress.StreetName;
    
                return objResult;
            }
        }
