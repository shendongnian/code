    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using TYPES;
    using BLLFactory;
    using BOFactory;
    using DALFactory;
    
    namespace WebApplication5
    {
        public partial class WebForm3 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                IFSBLL fsv = BLLFactory.FSBLLF.ViewList();
                List<IFSBO> des = fsv.viewallListBLL();
    
                GridView2.DataSource = fsv;
                GridView2.DataBind();
            }
    
            protected void Button2_Click(object sender, EventArgs e)
            {
    
            }
    
        }
    }
    --------------------------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using TYPES;
    using BLLFactory;
    using DALFactory;
    using BOFactory;
    
    namespace WebApplication5
    {
        public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    viewdata();
                }
            }
            private void viewdata()
            {
                List<IFSBO> fs = DALFactory.FSDALF.viewallListBO();
                GridView1.DataSource = fs;
                GridView1.DataBind();
            }
            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
            }
    
            protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                GridViewRow SelectedRow = GridView1.Rows[e.RowIndex];
                Label fsid = (Label)SelectedRow.FindControl("Label1") as Label;
                
                DateTime depdt = Convert.ToDateTime((SelectedRow.FindControl("TextBox5") as TextBox).Text);
                 DateTime desdt = Convert.ToDateTime((SelectedRow.FindControl("TextBox6") as TextBox).Text);
                 int pcf = Convert.ToInt32((SelectedRow.FindControl("TextBox7") as TextBox).Text);
                 int fcf = Convert.ToInt32((SelectedRow.FindControl("TextBox8") as TextBox).Text);
                 int ecf = Convert.ToInt32((SelectedRow.FindControl("TextBox9") as TextBox).Text);
    
    
    
    
    
                 int id = int.Parse(fsid.Text);
                 DateTime depdt1 = Convert.ToDateTime(depdt);
                 DateTime desdt1 = Convert.ToDateTime(desdt);
                 int pcf1 = Convert.ToInt32(pcf);
                 int fcf1 = Convert.ToInt32(fcf);
                 int ecf1 = Convert.ToInt32(ecf);
                 int a = 0; 
                 int x = pcf1;
                 int y = fcf1;
                 int z = ecf1;
    
                 if (x < y || x < z)
                 {
                     Response.Write("<script> alert('Premium class fare should not be lesser than First or Economy Class Fare')");
                     a++;
                          
                 }
                 if (y > x || y < z)
                 {
                     Response.Write("<script> alert('First class fare should not be greater than Premuium and should be greater than Economy Class')");
                     a++;
    
                 }
                if(z > y || z > x)
                {
                    Response.Write("<script> alert('Economy  class fare should not be greater than First or Economy Class Fare')");
                    a++;
    
                }
    
    
                if (a == 0)
                {
                    IFSBO boobj = BOFactory.FSBOF.EditFS(id, depdt1, desdt1, pcf1, fcf1, ecf1);
                    IFSBLL bllobj = BLLFactory.FSBLLF.Edit();
                    bool success = bllobj.editfs(boobj);
                }
    
            }
    
            protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
            {
                GridView1.EditIndex = e.NewEditIndex;
                viewdata();
            }
    
            protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
    
                GridView1.EditIndex = -1;
                viewdata();
    
     
            }
        }
    }
    -----------------------------------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TYPES
    {
       public  interface IFSDAL
        {
    
    
            List<IFSBO> viewallListBO();
    
            bool editFSS(IFSBO bb);
        }
    }
    
    -----------------------------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TYPES
    {
       public interface IFSBO
        {
            int FlightScheduleID { get; set; }
            string DepaarturePlace { get; set; }
            string DestinationPlace { get; set; }
            string Flight { get; set; }
            int AirBusID { get; set; }
            DateTime DepartureDateTime { get; set; }
            DateTime ArrivalDateTime { get; set; }
    
            double PremiumClassFare { get; set; }
            double FirstClassFare { get; set; }
            double EconomyClassFare { get; set; }
            int PremiumClassSeatingAvailability { get; set; }
            int FirstClassSeatingAvailability { get; set; }
            int EconomyClassSeatingAvailability { get; set; }
            double Vat { get; set; }
            double Tax { get; set; }
            int Distance { get; set; }
            bool Status { get; set; }
            string Description { get; set; }
        }
    }
    =======================================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TYPES
    {
      public  interface IFSBLL
        {
          List<IFSBO> viewallListBLL();
    
          bool editfs(IFSBO boobj);
        }
    }
    ===========================================================================================
    <?xml version="1.0"?>
    
    <!--
      For more information on how to configure your ASP.NET application, please visit
      http://go.microsoft.com/fwlink/?LinkId=169433
      -->
    
    <configuration>
        <system.web>
          <compilation debug="true" targetFramework="4.5" />
          <httpRuntime targetFramework="4.5" />
        </system.web>
    
      <connectionStrings>
        <add name="connstr" connectionString="Data Source=intvmsql01;Intial catalog=db05tms223;User Id=pj05tms223;Password=tcstvm;" />
    
      </connectionStrings>
      
    </configuration>
    ======================================================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    using System.Data.Sql;
    
    namespace DAL
    {
        class DButility
        {
            //public static SqlConnection getconnection()
            //{
            //    string con = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            //    SqlConnection conn = new SqlConnection(con);
            //    return conn;
            //}
        }
    }
    ==================================================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TYPES;
    using BOFactory;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace DAL
    {
       public class FSDAL:IFSDAL
        {
            List<IFSBO> fslist = new List<IFSBO>();
    
            public List<IFSBO> viewallListBO()
            {
                try
                {
                    string ConnectionString = "Data Source = intvmsql01;" +
                       "Initial Catalog = db05tms223;"
                       + "User id=pj05tms223;"
                       + "Password=tcstvm;";
    
                    SqlConnection connection = new SqlConnection(ConnectionString);
                    //SqlConnection connection = DButility.getconnection();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_viewfsd";
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int fsid = Convert.ToInt32(reader["FlightScheduleID"]);
                        string depplace = reader["DeparturePlace"].ToString();
                        string desplace = reader["DestinationPlace"].ToString();
                        string flight = reader["Flight"].ToString();
                        int abid = Convert.ToInt16(reader["AirBusID"]);
                        DateTime depdt = Convert.ToDateTime(reader["DepartureDateTime"]);
                        DateTime aridt = Convert.ToDateTime(reader["ArrivalDateTime"]);
                        double pcf = Convert.ToDouble(reader["PremiumClassFare"]);
                        double fcf = Convert.ToDouble(reader["FirstClassFare"]);
                        double ecf = Convert.ToDouble(reader["EconomyClassFare"]);
                        int pcsa = Convert.ToInt16(reader["PremiumClassSeatingAvailability"]);
                        int fcsa = Convert.ToInt16(reader["FirstClassSeatingAvailability"]);
                        int ecsa = Convert.ToInt16(reader["EconomyClassSeatingAvailability"]);
                        double vat = Convert.ToDouble(reader["Vat"]);
                        double tax = Convert.ToDouble(reader["Tax"]);
                        int dist = Convert.ToInt16(reader["Distance"]);
                        bool stat = Convert.ToBoolean(reader["Status"]);
    
    
                        IFSBO employee = BOFactory.FSBOF.viewfs(fsid, depplace, desplace, flight, abid, depdt, aridt, pcf, fcf, ecf, pcsa, fcsa, ecsa, vat, tax, dist, stat);
                        fslist.Add(employee);
    
                    }
                    connection.Close();
                   
                }
                catch(Exception)
                {
                   
                }
                return fslist;
            }
            public bool editFSS(IFSBO bb)
            {
                bool flag = false;
                string ConnectionString = "Data Source = intvmsql01;" + "Initial Catalog = db05tms223;" + "User id=pj05tms223;" + "Password=tcstvm;";
    
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_editFSD";
                command.Connection = connection;
                SqlConnection conn = new SqlConnection();
                command.Parameters.AddWithValue("@FlightScheduleID", bb.FlightScheduleID);
                command.Parameters.AddWithValue("@DepartureDateTime", bb.DepartureDateTime);
                command.Parameters.AddWithValue("@ArrivalDateTime", bb.ArrivalDateTime);
                command.Parameters.AddWithValue("@PremiumClassFare", bb.PremiumClassFare);
                command.Parameters.AddWithValue("@FirstClassFare", bb.FirstClassFare);
                command.Parameters.AddWithValue("@EconomyClassFare", bb.EconomyClassFare);
                
                int rowaffected = command.ExecuteNonQuery();
                connection.Close();
                if (rowaffected > 0)
                {
                    flag = true;
                }
                return flag;
            }
        }
    }
    =====================================================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TYPES;
    using DAL;
    
    namespace DALFactory
    {
      public  class FSDALF
        {
          
    
    
            public static List<IFSBO> viewallListBO()
            {
                IFSDAL cust = new FSDAL();
                List<IFSBO> cust1 = cust.viewallListBO();
                return cust1;
            }
    
            public static IFSDAL EditFS()
            {
                IFSDAL edit = new FSDAL();
                return edit;
            }
        }
    }
    =========================================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TYPES;
    using BO;
    
    namespace BOFactory
    {
       public  class FSBOF
        {
           
            
    
            public static IFSBO viewfs(int fsid, string depplace, string desplace, string flight, int abid, DateTime depdt, DateTime aridt, double pcf, double fcf, double ecf, int pcsa, int fcsa, int ecsa, double vat, double tax, int dist, bool stat)
            {
                IFSBO n = new FSBO(fsid, depplace, desplace, flight, abid, depdt, aridt, pcf, fcf, ecf, pcsa, fcsa, ecsa, vat, tax, dist, stat);
                return n;
            }
    
            public static IFSBO EditFS(int id, DateTime depdt1, DateTime desdt1, int pcf1, int fcf1, int ecf1)
            {
                IFSBO b = new FSBO(id, depdt1, desdt1, pcf1, fcf1, ecf1);
                return b;
            }
        }
    }
    ========================================================================================
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TYPES;
    using DALFactory;
    
    namespace BLL
    {
       public class FSBLL:IFSBLL
        {
            public List<IFSBO> viewallListBLL()
            {
                List<IFSBO> obj = DALFactory.FSDALF.viewallListBO();
                return obj;
            }
    
            public bool editfs(IFSBO bb)
            {
                IFSDAL obj3 = DALFactory.FSDALF.EditFS();
                bool edit = obj3.editFSS(bb);
                return edit;
            }
    
        }
    }
    =====================================================================================
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TYPES;
    using BLL;
    
    
    namespace BLLFactory
    {
       public  class FSBLLF
        {
            public static IFSBLL ViewList()
            {
                IFSBLL obll = new FSBLL();
                return obll;
            }
    
            public static IFSBLL Edit()
            {
                IFSBLL obll1 = new FSBLL();
                return obll1;
            }
        }
    }
