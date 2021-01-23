    static class Program
    {
         public static string CompanyConnectionString;
         static void Main()
         {
              string domain = Environment.UserDomainName;
              SqlConnectionStringBuilder sbc = new SqlConnectionStringBuilder();
              if(domain == "CompanyA")
              {
                   sbc.DataSource = "ServerForComapanyA";
                   sbc.InitialCatalog = "DataBaseCompanyA";
                   ... etc ... 
                   ... other properties of class SqlConnectionStringBuilder ...
                   ... to exactly compose the connection string required
              }
              else if(domain == "CompanyB")
              {
                   sbc.DataSource = "ServerForComapanyB";
                   sbc.InitialCatalog = "DataBaseCompanyB";
                   ... etc ... 
                   ... other properties of class SqlConnectionStringBuilder ...
                   ... to exactly compose the connection string required
              }
              else
              {
                   MessabeBox.Show("Machine domain name not recognized. Unable to connect");
              }
              Program.ConnectionString = sbc.ConnectionString;
              ....
