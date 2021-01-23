    namespace Test
    {
    class Program
    {
    
        static void Main(string[] args)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
           string InputDirectory = @"My Documents\\2015";
            string FileMask = "comb*.txt";
         
            try
            {
                string line = null;
                var Files = Directory.GetFiles(InputDirectory, FileMask, SearchOption.AllDirectories).Select(f => Path.GetFullPath(f));
                foreach (var f in Files)
                {
                    DataTable table = new DataTable();
                    table.TableName = f;
                    table.Columns.Add("ID", typeof(Int64));
                    table.Columns.Add("dob", typeof(string));
                    table.Columns.Add("size", typeof(string));
                    table.Columns.Add("accountno", typeof(string));
                    
                    
                    
                    using (StreamReader reader = new StreamReader(f))
                    {
                     
                        
                        while ((line = reader.ReadLine()) != null)
                        {
                            
                                string[] values = line.Split(',').Select(sValue => sValue.Trim()).ToArray();
                                string uniqueGuid = SequentialGuidGenerator.NewGuid().ToString();
                                uniqueGuid = uniqueGuid.Replace("-", "");
                                int ID = convert.toint(values[0]);
                                
                                string NOTIF_ID = "";
                                table.Rows.Add(ID,values[1].ToString(),values[2]).toString(),values[2]).toString());
                            
                        }
                        reader.Close();
                    }
                    utilityClass.Insert_Entry(table, env);
                }
            }
            catch (Exception e)
            {
                CustomException.Write(CustomException.CreateExceptionString(e));
            }
        }
    }
    }
