    public class Firm {
      public Firm(DB.Firm firm) {
        Address = firm.Address;
        Email = firm.Email;
        City = new DTO.City() {
          CityName = firm.City.City1;
          ZipCode = firm.City.ZipCode;
        };
        // etc.
      }
      
      public string Address { get; set;}
      public string Email { get; set; }
      public DTO.City City { get; set; }
      // etc.
    
      public static explicit operator Firm(DB.Firm f) {
        return new Firm(f);
      }
    }
