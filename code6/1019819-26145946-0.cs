    public static class Extensions
        {
            public static DTO.Firm ToDto(this DB.Firm firm)
            {
               var result = new DTO.Firm();
               result.Address = firm.Address;
               result.Address2 = firm.Address2;
               //...
    
               return result;    
            }
        }
