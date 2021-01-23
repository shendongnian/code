    public NaiveBayes[] ReadOBj()
    {
    	SqlConnection conn = new SqlConnection(connectionString);
    	SqlCommand command = new SqlCommand(@"SELECT NAME, CODE, DEPARTMENT, TS, CD, REPEAT,        CORE, [Content], Grade 
    	FROM Transcript
    	WHERE (Grade <> 'UNKNOWN')", conn);
    	
    	conn.Open();
    	SqlDataReader reader = command.ExecuteReader();
    	List<NaiveBayes> a = new List<NaiveBayes>();
    
    	while (reader.Read())
    	{
    		NaiveBayes1.NaiveBayes na = new NaiveBayes();
    		na.Name = (string)reader["NAME"];
    		na.Dept = reader["DEPARTMENT"].ToString();
    		Boolean.TryParse(reader["CORE"].ToString(), out na.Core);
    		Boolean.TryParse(reader["REPEAT"].ToString(),out na.Repeat);
    		int.TryParse(reader["TS"].ToString(),out na.TS) ;
    		int.TryParse(reader["CD"].ToString(),out na.CD);
    		na.Content = reader["Content"].ToString();
    		na.Grade = reader["Grade"].ToString();
    
    		a.Add(na);
    	}
    
    	conn.Close();
    	return a.ToArray();
    }
