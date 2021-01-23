    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public namespace whatever.mynamespace
        [Table("dbo.ContactLogSummaries")] //<-- this is your view
        public class ContactLogSummary
        {
            ...
        }
    }
