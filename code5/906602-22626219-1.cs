    var insuranceCard = result.Select(row => 
    { 
         var s = new Student();
         s.MotherContacts.Items.Add(ContactDetailType.PHONE, row.Field<string>("MotherPhone");
         s.MotherContacts.Items.Add(ContactDetailType.MOBILE, row.Field<string>("MotherMobile");
         return s;
    }).FirstOrDefault();
