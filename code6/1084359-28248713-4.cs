    List<PhoneDictionary> table = new List<PhoneDictionary>() 
                { 
                
                 new PhoneDictionary { Phone1 = 1, Phone2 =2},
                 new PhoneDictionary { Phone1 = 1, Phone2 =2},
                 new PhoneDictionary { Phone1 = 2, Phone2 =3},
                 new PhoneDictionary { Phone1 = 3, Phone2 =4},
                 new PhoneDictionary { Phone1 = 3, Phone2 =4},
                };
    
    
     var phones = table.ToString(",",x => x.Phone1.ToString());
