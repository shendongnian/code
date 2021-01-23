    using System.Collections.Generic.ObjectModel
    public class PersonDictionary : KeyedCollection<PersonDescription>
    {
        protected override int GetKeyforItem(PersonDescription description)
        {
            return description.Personid; // hope it's on this class!
        }
    } 
