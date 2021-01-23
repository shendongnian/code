    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace PhoneService
    {
       class PhoneBook : IPhoneBook
       {
         private static List<Contact> _contactList = new List<Contact>();
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
