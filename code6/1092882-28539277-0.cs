    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class StudentWebService : System.Web.Services.WebService {
    
        public StudentWebService () {
    
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
    
        [WebMethod]
        public DataTable GetStudents()
        {
            string constr = @"Server=WAQAS\SQLEXPRESS; Database=SampleDB; uid=sa; pwd=123";
            string query = "SELECT ID, Name, Fee FROM Students";
            SqlDataAdapter da = new SqlDataAdapter(query, constr);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
    
        [WebMethod]    
        public int UpdateStudent(int id, string name, decimal fee)
        {
            SqlConnection con = null;
            string constr = @"Server=WAQAS\SQLEXPRESS; Database=SampleDB; uid=sa; pwd=123";
            string query = "UPDATE Students SET Name = @Name, Fee = @Fee WHERE ID = @ID";
    
            con = new SqlConnection(constr);
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add("@Fee", SqlDbType.Decimal).Value = fee;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
    
            int result = -1;
            try
            {
                con.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception)
            { }
            finally
            {
                con.Close();
            }
            return result;
        }    
    }
