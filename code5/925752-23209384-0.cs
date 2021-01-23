    using (XmlReader reader = XmlReader.Create(filepath))
    {
       while(reader.Read())
       {
          if (reader.IsStartElement())
          {
             switch (reader.Name)
             {
                case "Candidate":
                string name = reader["CandidateName"];
                break;
    
                case "Vote":
                string voteStr = reader["VoteString"];
                break;
             }
          }
       }
    }
