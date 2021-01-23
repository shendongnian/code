    var apartment =
    (from a in apartmentXml.Descendants("Apartment")
    where (a.Attribute("street_name").Value == newApartment.StreetName) &&
          (a.Element("Huose_Num").Value == newApartment.HouseNum.ToString())
    select new { 
          street_name = a.Attribute("street_name").Value,
          Huose_Num = a.Element("Huose_Num").Value,
          Num_Of_Rooms = a.Element("Num_Of_Rooms").Value,
          Price = a.Element("Price").Value,
          Flags = (from f in a.Element("Flags")
                      select new { 
                        Elevator = f.Element("Elevator").Value,
                        Floor =  f.Element("Floor").Value,
                        parking_spot = f.Element("Floor").Value,
                        balcony = f.Element("balcony").Value,
                        penthouse = f.Element("penthouse").Value,
                        status_sale = f.Element("status_sale").Value
                        })
                     }).FirstOrDefault();
    if(aparment == null) 
    {
       Console.WriteLine("Sorry, Apartment at {0} or at num {1}", newApartment.StreetName,
        newApartment.HouseNum);
    } 
    else 
    {
       Console.WriteLine(apartment.street_name);
       Console.WriteLine(apartment.Huose_Num);
       Console.WriteLine(apartment.Num_Of_Rooms);
       Console.WriteLine(apartment.Price);
       Console.WriteLine(apartment.street_name);
       Console.WriteLine(apartment.Flags.Elevator);
       Console.WriteLine(apartment.Flags.Floor);
       Console.WriteLine(apartment.Flags.parking_spot);
       Console.WriteLine(apartment.Flags.balcony);
       Console.WriteLine(apartment.Flags.penthouse);
       Console.WriteLine(apartment.Flags.status_sale);
    
    }
