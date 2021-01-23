    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
         
        static void Main()
        {
            string[] data = new String[]{"John, Smith, jsmith@nbcc.ca, (506) 555-1234","Frank, Sinatra, fsinatra@nbcc.ca, (506) 696-1234","Joan, Rivers, jrivers@nbcc.ca, (506) 696-5678","Freddy, Mercury, fmercury@nbcc.ca, (506) 653-1234","Freddy, Kruger, fkruger@nbcc.ca, (506) 658-1234"};
            ContactList contacts = new ContactList(data);
            contacts.getLastNames();
    
        }
    }
    
    
    public class ContactList
    {
        private List<string> cList;
        public List<string> CList{
            get{ return cList; }
        }
        
        public ContactList(string[] _contactList){
            
            this.cList = _contactList.ToList();
        }
    
    
        public void getLastNames()
        {
            this.cList.ForEach( x => Console.WriteLine(x.Split(',')[0]));
        }
        
    }
        
