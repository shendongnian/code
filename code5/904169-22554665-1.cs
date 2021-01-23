    namespace Panda.DataTransferObjects
    {
        public class PersonDto
        {
            public int? Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public byte[] RowVersion { get; set; }
        }
        public class CreatePersonDto
        {
            public string FirstName { get; set; }
            public string Surname { get; set; }
        }
        public class EditPersonDto
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public byte[] RowVersion { get; set; }
            // user context info, i would usually use a separate ServiceContextDto to do
            // this, if you need to store whom changed what and when, and how etc 
            // ie. log other information of whats going on and by whom.
            // Needed in Create and Edit DTO's only
            public string ChangedBy { get; set; }
        }
        public class ListPersonDto
        {
            public string Name { get; set; }
        }
        public class QueryPersonDto
        {
            public int? Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
        }
    }
