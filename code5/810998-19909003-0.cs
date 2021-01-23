    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace Program
    {
        public class ContactPersonType
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
    
        public class ContactPerson
        {
            public ContactPersonType JobRole { get; set; }
    
            public static ObservableCollection<ContactPerson> GetContactPerson()
            {
                var contactPersons = new ObservableCollection<ContactPerson>();
                XElement doc = XElement.Load("contactpersoon.xml");
                var contacts = doc.Elements("contact");
    
                for (int i = 0; i < contacts.Count(); i++)
                {
                    contactPersons.Add(new ContactPerson
                    {
                        JobRole = new ContactPersonType
                        {
                            ID = i.ToString(),
                            Name = contacts.ElementAt(i).Element("jobrole").Value
                        }
                    });
                }
    
                return contactPersons;
            }
        }
    }
