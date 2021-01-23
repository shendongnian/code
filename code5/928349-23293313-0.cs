    using System;
    using Microsoft.SqlServer.Types;
    using System.Data.SqlClient;
    using System.Data;
    
    namespace ConsoleApplication4
    {
    	class Program
    	{
    		static void Main()
    		{
    			var geom1 = SqlGeography.STGeomFromText(
                            new System.Data.SqlTypes.SqlChars(
                            "LINESTRING(-122.360 47.656, -122.343 47.656)"), 4326);
    			var geom2 = SqlGeography.STGeomFromText(
                            new System.Data.SqlTypes.SqlChars(
                            "LINESTRING(-100.0 45.0, -1420 49.0)"), 4326);
    			using(var conn = new SqlConnection(
                      @"Server=Server;Database=master;Integrated Security=SSPI;"))
    			{
    				using (var cmd = new SqlCommand(
                        "select @parm1.STIntersects(@parm2)", conn))
    				{
    					var p1 = cmd.Parameters.Add("@parm1", SqlDbType.Udt);
    					p1.UdtTypeName = "geography";
    					p1.Value = geom1;
    					var p2 = cmd.Parameters.Add("@parm2", SqlDbType.Udt);
    					p2.UdtTypeName = "geography";
    					p2.Value = geom2;
    					conn.Open();
    					Console.WriteLine(cmd.ExecuteScalar());
    				}
    			}
    			Console.ReadLine();
    		}
    	}
    
    }
