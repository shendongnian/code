    public class Customer {
      public string CusID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
    [WebMethod(Description = "yet another test .....")]
    [ScriptMethod]
    public object GetCustomerByIDTRY() {
      string connString = System.Configuration.ConfigurationManager.ConnectionStrings["my_domain_mysql"].ConnectionString;
      MySqlConnection connection1 = new MySqlConnection(connString);
      MySqlCommand cmd = new MySqlCommand("SELECT Vet_Users.FirstName, Vet_Users.LastName, Vet_Users.UserID, Vet_Customer.CusID FROM Vet_Users JOIN Vet_Customer ON Vet_Users.UserID=Vet_Customer.UserID");
      DataSet CusIDDataSet = new DataSet();
      MySqlDataAdapter CusIDDataAdapter = new MySqlDataAdapter(cmd);
      CusIDDataAdapter.SelectCommand.Connection = connection1;
      CusIDDataAdapter.Fill(CusIDDataSet, "reading");
      connection1.Close();
      var customers = new List<Customer>();
      foreach (DataRow rs in CusIDDataSet.Tables[0].Rows) {
        customers.Add(new Customer {
          CusID = rs["CusID"].ToString(),
          FirstName = rs["FirstName"].ToString(),
          LastName = rs["LastName"].ToString()
        });
      }
      return new {
        NumberOfCustomers = CusIDDataSet.Tables[0].Rows.Count.ToString(),
        Customer = customers
      };
    }
