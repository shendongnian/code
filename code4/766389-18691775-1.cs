	using System;
	using System.Data.OleDb;
	namespace StackoverflowExcel
	{
		class Program
		{
			static void Main()
			{
				using(var myConnection = new OleDbConnection(GetExcelConnectionStringByWrite()))
				using (var myCommand = new OleDbCommand())
				{
					myConnection.Open();
					myCommand.Connection = myConnection;
					myCommand.CommandText =
						"UPDATE [usefulinformation] SET Status ='Imported' WHERE Status IN ( SELECT TOP 5 Status FROM [usefulinformation] )";
					myCommand.ExecuteNonQuery();
					myConnection.Close();
				}
				Console.WriteLine("Done");
				Console.ReadKey();
			}
			private static string GetExcelConnectionStringByWrite()
			{
				return
					@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\cys\desktop\Test.xlsx;Extended Properties='Excel 12.0;HDR=YES;IMEX=0;MAXSCANROWS=10;READONLY=FALSE'";
			}
		}
	}
