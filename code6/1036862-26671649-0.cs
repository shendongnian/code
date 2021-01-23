    public ActionResult Create([Bind(Include = "fname,lname,cell")]MembersViewModel memberViewModel)
    {
        Head head = context.Heads.FirstOrDefault(x => x.cell.Equals(memberViewModel.cell));
        // now we have a Head entity to reference
        var client = new Member
        {
            fname = memberViewModel.fname,
            lname = memberViewModel.lname,
            initial = memberViewModel.initial,
            title_id = memberViewModel.title_id,
            dob = memberViewModel.dob,
            maritial = memberViewModel.maritials,
            religion = memberViewModel.religion,
            occupation = memberViewModel.occupation,
            company = memberViewModel.company,
            Note = memberViewModel.note,
            employed = memberViewModel.employed,
            reg_date = memberViewModel.regdate,
            
            AccNumb = memberViewModel.accNumb,
            Hnumber = memberViewModel.hnumber,
            Active = memberViewModel.active,
            AgeGrp = memberViewModel.agegroup,
            h_id = head.h_id,                      // this is where we set Member.h_id
        };
        var client1 = new Addresses1();
        var contact = new Contact();
        using (var context = new ParishDBSQLEntities())
        {
            context.Members.Add(client);                
            client1.h_ID = head.h_id;               // using head entity as reference again
            client1.strNo = memberViewModel.strNo;
            client1.strname = memberViewModel.strname;
            client1.Suburb = memberViewModel.suburb;
            client1.City = memberViewModel.city;
            client1.Province = memberViewModel.province;
            client1.Country = memberViewModel.country;
            client1.PostalCode = memberViewModel.postalcode;
            client1.zone = memberViewModel.zone;
            client1.flatName = memberViewModel.flatName;
            client1.flatNo = memberViewModel.flatNo;
            client1.IsHa = memberViewModel.isHa;
            client1.AddType = memberViewModel.addtype;
            context.Addresses1.Add(client1);
            contact.Email = memberViewModel.email;
            contact.cell = memberViewModel.cell;
            contact.cell2 = memberViewModel.cell;
            contact.tel_h = memberViewModel.tel_h;
            contact.tel_w = memberViewModel.tel_w;
            contact.fax = memberViewModel.fax;
            contact.m_id = client.m_id;              // NB
           context.Contacts.Add(contact);
            context.SaveChanges();
        }
