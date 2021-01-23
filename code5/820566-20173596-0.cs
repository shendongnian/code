    public class SampleService : System.Web.Services.WebService
        {
            SqlConnection con;
            SqlCommand cmd;
    
            [WebMethod]
            public int insertPerson(string firstName, string lastName, string DOB, int phoneNumber, string address, int postCode)
            {
    String connectionstring=System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    
                con = new SqlConnection(connectionstring);
                con.Open();
                cmd = new SqlCommand("INSERT INTO person (firstName, lastName, DOB, phoneNumber, address, postCode) VALUES (@firstName, @lastName, @DOB, @phoneNumber, @address, @postCode)", con);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@postCode", postCode);
                int roweffected = cmd.ExecuteNonQuery();
    
    
                return roweffected;
            }
