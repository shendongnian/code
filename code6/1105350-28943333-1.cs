    public class Repository {
        public IEnumerable<string> GetNamesFromTuzel()
        {
            // All of the same logic
            while (myReader.Read())
            {
                yield return myReader["name"].ToString() + " " + 
                    myReader["Surname"].ToString();
            }
        }
    }
