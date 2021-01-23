    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    namespace CsvImportTest
    {
        class Program
        {
            static string FilePath = @"C:\Users\Public\test\CsvImportTest\TestData.csv";
            static void Main(string[] args)
            {
                ImportCsvIntoTemp();
                Console.WriteLine("Done.");
            }
            private static void ImportCsvIntoTemp()
            {
                try
                {
                    CreateCsvSchemaFile();
                    string query = @"SELECT * INTO TEMP_CSV 
                                    FROM [Text;HDR=no;Database={0}].[{1}]";
                    query = String.Format(query, Path.GetDirectoryName(FilePath), Path.GetFileName(FilePath));
                    //AccessDb.Query(AccessDbConnString, query);
                    using (OleDbConnection con = new OleDbConnection())
                    {
                        con.ConnectionString =
                                @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                @"Data Source=C:\Users\Public\test\CsvImportTest\MyDb.mdb;";
                        con.Open();
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    string message = String.Format("CSV file import failed. Inner Exception: {0}", ex.Message);
                    Console.WriteLine(message);
                    //throw new ImportFailedException(message);
                }
            }
            private static void CreateCsvSchemaFile()
            {
                using (FileStream fs = new FileStream(Path.GetDirectoryName(FilePath) + "\\schema.ini", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("[" + Path.GetFileName(FilePath) + "]");
                        sw.WriteLine("ColNameHeader=True");
                        //sw.WriteLine("MaxScanRows=0");
                        sw.WriteLine("Format=Delimited(;)");
                        sw.WriteLine("DateTimeFormat=yyyy-MM-dd");
                        sw.WriteLine("CharacterSet=ANSI");
                        sw.WriteLine("DecimalSymbol=,");
                        sw.WriteLine("Col1=\"Operating Unit Organization Name\" Text Width 255");
                        sw.WriteLine("Col2=\"Year\" Long");
                        sw.WriteLine("Col3=\"Sales Rep Name\" Text Width 255");
                        sw.WriteLine("Col4=\"Date\" DateTime");
                        sw.WriteLine("Col5=\"Week\" Text Width 255");
                        sw.WriteLine("Col6=\"Product Number\" Text Width 255");
                        sw.WriteLine("Col7=\"Account Name\" Text Width 255");
                        sw.WriteLine("Col8=\"Customer Number\" Text Width 255");
                        sw.WriteLine("Col9=\"Corporate Brand\" Text Width 255");
                        sw.WriteLine("Col10=\"Brand\" Text Width 255");
                        sw.WriteLine("Col11=\"Ordered Quantity\" Long");
                        sw.WriteLine("Col12=\"Amount\" Currency");
                        sw.Close();
                        sw.Dispose();
                    }
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
    }
