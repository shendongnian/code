    namespace App01.Win8.DataModel
    {
        public class VoidListElement
        {
            public VoidListElement(string firstname, string lastname)
            {
                this.FirstName = firstname;
                this.LastName = lastname;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
