    using System;
    using System.Data;
    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess.Types;
    
    namespace ConsoleApplication1
    {
      class Class1
      {
    
        [STAThread]
        static void Main(string[] args)
        {
          try
          {	
            string conString = "User Id=scott;Password=tiger;Data Source=orcl;Pooling=false;";
    
            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();
    
            string cmdtxt = "BEGIN " +
              "OPEN :1 for select ename, deptno from emp where deptno = 10; " +
              "OPEN :2 for select ename, deptno from emp where deptno = 20; " +
              "OPEN :3 for select ename, deptno from emp where deptno = 30; " +
              "END;";
    
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = cmdtxt;
    
            OracleParameter p1 = cmd.Parameters.Add("refcursor1",
                OracleDbType.RefCursor);
            p1.Direction = ParameterDirection.Output;
    
            OracleParameter p2 = cmd.Parameters.Add("refcursor2",
                OracleDbType.RefCursor);
            p2.Direction = ParameterDirection.Output;
    
            OracleParameter p3 = cmd.Parameters.Add("refcursor3",
                OracleDbType.RefCursor);
            p3.Direction = ParameterDirection.Output;
    
    
            cmd.ExecuteNonQuery();
    
    
            OracleDataReader dr1 =
              ((OracleRefCursor)cmd.Parameters[2].Value).GetDataReader();
            OracleDataReader dr2 =
              ((OracleRefCursor)cmd.Parameters[1].Value).GetDataReader();
    
    
            while (dr1.Read() && dr2.Read())
            {
              Console.WriteLine("Employee Name: " + dr1.GetString(0) + ", " +
                  "Employee Dept:" + dr1.GetDecimal(1));
              Console.WriteLine("Employee Name: " + dr2.GetString(0) + ", " +
                  "Employee Dept:" + dr2.GetDecimal(1));
              Console.WriteLine();
            }
    
            Console.WriteLine("Press 'Enter' to continue");
            Console.ReadLine();
    
    
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);
            Console.WriteLine(ex.Data);
          }
        }
      }
    }
