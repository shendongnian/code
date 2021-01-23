    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
     namespace Employe
     {
       public class Employe : GlobalClass
    {
        public Employe()
        {
        }
     //Sample Method 
         public DataTable FillRoleComboBox()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand("select * from TBLEMPLOYEE", conn);
            SqlDataAdapter SDA = new SqlDataAdapter(comm);
            SDA.SelectCommand = comm;
            SDA.Fill(dt);
            return dt;
        }
    }
    }
