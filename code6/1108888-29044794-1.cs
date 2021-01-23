    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
         
        static void Main()
        {
            // Just to hold data
            string[] data = new String[]{"John, Smith, jsmith@nbcc.ca, (506) 555-1234","Frank, Sinatra, fsinatra@nbcc.ca, (506) 696-1234","Joan, Rivers, jrivers@nbcc.ca, (506) 696-5678","Freddy, Mercury, fmercury@nbcc.ca, (506) 653-1234","Freddy, Kruger, fkruger@nbcc.ca, (506) 658-1234"};
            
            // Create new contact list object
            ContactList contacts = new ContactList(data);
            
            // Call our method
            contacts.PrintLastNames();
    
        }
    }
    
    
    public class ContactList
    {
        // Declare properties
        // google C# getter setter
        private List<string> cList;
        public List<string> CList{
            get{ return cList; }
        }
        
        // Constructor
        public ContactList(string[] _contactList)
        {
            // When creating new instance, take array of contacts and put into list    
            this.cList = _contactList.ToList();
        }
        
        // This will print out the names
        public void PrintLastNames()
        {
            // Google lambda expression C# for more info on iteration
            // With each string in cList, split by comas and use the first element 
            this.cList.ForEach( x => Console.WriteLine(x.Split(',')[0]));
            
            // Use this for last names
            //this.cList.ForEach( x => Console.WriteLine(x.Split(',')[1]));
        }
        
        // This will return names in list
        public List<string> GetLastNames()
        {
            // Google List Collection Generic C# for more info
            List<string> namesList = new List<string>();
            this.cList.ForEach( x => namesList.Add( x.Split(',')[0] ));
            
            return namesList;
        }
        
    }
        
