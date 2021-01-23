    // GET: /ReportData
    public ActionResult Index()
    {
        List<DataHolder> data = new List<DataHolder>();
        using (SqlConnection connection = new SqlConnection(@"Data Source=xxx.xxx.xxx.xxx;Initial Catalog=xxxxxx;Persist Security Info=True;User ID=xxxxx;Password=xxxxx"))
        {
  
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"select * from ProjectManagement as p 
                join Implementation as i on p.JobNumber = i.JobNumber 
                join Divisions as d on i.Division = d.Division 
                where p.ProjectStatus = 'Active'"
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {                  
                    while (reader.Read())
                    {
                       data.Add( new DataHolder {
                          Item1 = reader.GetValue(0),
                          Item2 = reader.GetValue(1)
                       });
                        // process result
                        //reader.GetValue(0);
                        //reader.GetValue(1);
                        //reader.GetValue(2);
                        //reader.GetValue(3);
                        //reader.GetValue(4);
                        //reader.GetValue(5);
                    }
                    
                }
            }
        }         
        return View(data);
    }
    public class DataHolder {
      public string Item1 { get; set; }
      public string Item2 { get; set; }
    }
