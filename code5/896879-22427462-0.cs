    using System;
    using System.Data;
    using lcpi.data.oledb; //LCPI .NET Data Provider for OLEDB
    
    namespace ConsoleApplication1
    {
     class Program
     {
      private const string c_cn_str
       ="provider=LCPI.IBProvider.3;"
       +"location=localhost:d:\\database\\ibp_test_fb25_d3.gdb;"
       +"user id=gamer;"
       +"password=vermut;"
       +"dbclient_library=fbclient.dll";
    
      static void Main(string[] args)
      {
       try
       {
        using(var cn=new OleDbConnection(c_cn_str))
        {
         cn.Open();
    
         using(var tr=cn.BeginTransaction(IsolationLevel.RepeatableRead))
         {
          using(var cmd=new OleDbCommand("",cn,tr))
          {
           cmd.CommandText
            ="insert into BIN_BLOB_TABLE (BIN_DATA) values(:bin)\n"
             +"returning TEST_ID\n"
             +"into :id";
          
           cmd["bin"].Value=new byte[]{1,2,3};
          
           cmd.ExecuteNonQuery();
    
           var rec_id=cmd["id"].Value;
    
           cmd.CommandText
            ="select BIN_DATA from BIN_BLOB_TABLE where TEST_ID=:x";
    
           cmd["x"].Value=rec_id;
    
           var data=(byte[])cmd.ExecuteScalar();
    
           for(int i=0;i!=data.Length;++i)
            Console.WriteLine("[{0}]: {1}",i,data[i]);
          }//using cmd
          tr.Commit();
         }//using tr
        }//using cn
       }
       catch(Exception e)
       {
        Console.WriteLine("ERROR: {0} - {1}",e.Source,e.Message);
       }//catch
      }//Main
     }//Program
    }//namespace ConsoleApplication1
