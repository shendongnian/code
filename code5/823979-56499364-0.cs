`
<add name="myclient_0Entities" connectionString="metadata=
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.csdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.ssdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.msl;
     provider=MySql.Data.MySqlClient;provider connection string=&quot;
      server=localhost;user id=xxxx;password=yyyyy;
     persistsecurityinfo=True;database=myclient_0&quot;" providerName="System.Data.EntityClient" />
`
You might have to dig a bit because the wizard is not good about putting in \n in appropriate places.
Notice that this connection string is fundamentally the same as the initial connection string except for its name and the fact that it has 
`
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.csdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.ssdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.msl;
`
The res: strings are needed by the data entity and its why you can't just send a standard connection string into the data entity.
If you try to send in the initial connection string 
`
 <add name="DefaultClientConnection" providerName="MySql.Data.MySqlClient" 
        connectionString="server=localhost;user id=xxx;
         password=xxxx; persistsecurityinfo=True;database=clientdb_0" />
`
you will get an exception from 
`
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
`
**Step3**
This new connection string is the one you need to alter. I have not tested it but I am pretty sure if change the data entity model with the wizard  you will need to make this change again.
Take string:
`
<add name="myclient_0Entities" connectionString="metadata=
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.csdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.ssdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.msl;
     provider=MySql.Data.MySqlClient;provider connection string=&quot;
      server=localhost;user id=xxxx;password=yyyyy;
     persistsecurityinfo=True;database=myclient_0&quot;" providerName="System.Data.EntityClient" />
`
and change it to:
`
<add name="myclient_0Entities" connectionString="metadata=
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.csdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.ssdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.msl;
     provider=MySql.Data.MySqlClient;provider connection string=&quot;
      server=localhost;user id=xxxx;password=yyyyy;
     persistsecurityinfo=True;database={0}&quot;" providerName="System.Data.EntityClient" />
`
Notice that the only part changed is database=myclient_0  to  database={0}
**Step 4**
The data entity created some code behind  **ClientDbUserUpdater.edmx**. The file is called **ClientDbUserUpdater.Context.cs**.
The code is ...
`
namespace what.ever.your.namespace.is
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class client_0Entities : DbContext
    {
        public client_0Entities()
            : base("name=client_0Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<user> users { get; set; }
    }
}
`
Notice that this a partial class.  This means you can extend this class and add a new constructor.
Add the following class.
`
using System;
using System.Configuration ;
using System.Data.Entity ;
namespace what.ever.your.namespace.is
{  
  public partial class client_0Entities : DbContext
  {
    public client_0Entities(string dbName) : base(GetConnectionString(dbName))
    {
    }
    public static string GetConnectionString(string dbName)
    {       
       var connString = ConfigurationManager.ConnectionStrings["client_0Entities"].ConnectionString.ToString();
      // obviously the next 2 lines could be done as one but creating and 
      // filling a string is better for debugging.  You can see what happened 
      // by looking a  conn
      // return  String.Format(connString, dbName);
      string conn =  String.Format(connString, dbName);
      return conn ;
    }
  } 
}
`
The class adds a new constructor which allows you to get the base connection string for the data entity model which from above looks like:
`
<add name="myclient_0Entities" connectionString="metadata=
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.csdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.ssdl|
    res://*/Areas.Authorizations.Models.ClientDbUserUpdater.msl;
     provider=MySql.Data.MySqlClient;provider connection string=&quot;
      server=localhost;user id=xxxx;password=yyyyy;
     persistsecurityinfo=True;database={0}&quot;" providerName="System.Data.EntityClient" />
`
and modfiy it at run time to change the schema.
The String.Format() call in the new partial class swaps out the database schema name in this connection string at run time.
At this point all configuration is done.
**Step 5** 
Now you can make it go. For better understanding of this example it is nice to know what the model looks like for this entity.  It is very simple because I was just testing and trying to make it go.
Drilling down through **ClientDbUserUpdater.edmx** and into into **ClientDbUserUpdater.tt** you will find your model in modelname.cs . My model is called "user"  so my file name is called user.cs
namespace what.ever.your.namespace.is
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
`       
Now you can generally access your model like this.        
`   
 client_0Entities _client_0Entities = new client_0Entities("schemaName");
`
and this code can be anywhere in your solution that can see class client_0Entities.
which in practice is a line similar to any of the 3 below which are connection to databases  client_19, client_47 and client_68 respectively.
`   
 client_0Entities _client_0Entities = new client_0Entities("client_19");
 client_0Entities _client_0Entities = new client_0Entities("client_47");
 client_0Entities _client_0Entities = new client_0Entities("client_68");
`
the following is an actual code example that works on my system.  Obviously I am going to not hard code in "client_19" but its better for demo purposes.
here is actual code with real names that works and adds a new row to the user table on database client_19
`
  string _newSchema = "client_19"
  using(client_0Entities _client_0Entities = new client_0Entities(_newSchema))
  {
     user _user = new user();
     _user.UserId = 201;
     _user.Email = "someone@someplace.com"
     _user.FirstName ' "Someone"; 
     _user.LastName  = "New";
     _user.Active = true;
     client_0Entities.users.Add ( _user ) ;
     client_0Entities.SaveChangesAsync ( ) ;
  }
`
Hopefully this helps some people.  I spent about 20 hrs looking at different solutions which simply did not work or provide enough information to complete them.  As I said,  finding Franciso's example allowed me to get it working.  
Regards,
