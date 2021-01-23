    using System;
    
    using MicroLite.Mapping;
    using MicroLite;
    
    namespace MailOut.Model
    {
        [Table("Mail")]
        public class Email
        {
            [Identifier(IdentifierStrategy.DbGenerated)]
            [Column("priKey")]
            public Int64 PriKey { get; set; }
    
            [Column("toemail")]
            public string ToEmail { get; set; }
    
            [Column("fromemail")]
            public string FromEmail { get; set; }
    
            [Column("body")]
            public string Body { get; set; }
        }
    }
