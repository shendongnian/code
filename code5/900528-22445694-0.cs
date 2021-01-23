    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace PhoneService
    {
       class PhoneBook : IPhoneBook
       {
         private static List<Contact> _contactList;
        //constructor
         public PhoneBook (List<Contact> contactList) 
         {
            _contactList = contactList;     
         }
         public PhoneBooks()
         {
         }
       }
    }
