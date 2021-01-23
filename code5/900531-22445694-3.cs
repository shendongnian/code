    using System;
    class Program
    {
      static void Main()
       {
        
         var contactList = new List<Contact>();
         contactList.Add(new Contact("Mary Jones", 1800252525));
         contactList.Add(new Contact("Bob Smith", 1800343434));
         contactList.Add(new Contact("Martin Dunne", 1800797979));
         contactList.Add(new Contact("Sarah Mitchel", 1800898989));  
	
         var phoneBook = new PhoneBook(contactList);
      }
    }
