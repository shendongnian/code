    try 
    {
        using(SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QABase;Integrated Security=True")
        {
            conn.open();
            using(SqlCommand myCommand = new SqlCommand("select * from EnglishVerbs where BaseForm = @VerbToFind or PastForm = @VerbToFind or PastPartForm = @VerbToFind", conn))
            {
                myCommand.Parameters.AddWithValue("VerbToFind", verb.ToLower());
                using(myReader = myCommand.ExecuteReader())
                {
                     while (myReader.Read())
                     {
                         v = new Verb();
                         v.BaseTense = Convert.ToString(myReader["BaseForm"]);
                         v.PastTense = Convert.ToString(myReader["PastForm"]);
                         v.PastParticiple = Convert.ToString(myReader["PastPartForm"]);
                         verbsToReturn.Add(v);
                     }
                }
            }
        }
    }
    catch(Exception e)
    {
        System.Console.WriteLine(e.ToString());
        throw; //Rethrow exception to let caller know that something went wrong
    }
