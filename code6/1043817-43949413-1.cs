    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    
    namespace LiteRemit.Models
    {
        public class MySqlCon : DbContext
        {
            //MySql Database connection String
            public MySqlCon() : base(nameOrConnectionString: "DefaultConnection") { }
            public virtual DbSet<CustomerModel> Customers { get; set; }
        }
    }
