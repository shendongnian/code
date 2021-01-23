    public LinkedList<Station> getAllStation()
    {
        string conString = "...";
        LinkedList<Station> st = new LinkedList<Station>();
    
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
    
           using (SqlCommand com = new SqlCommand("Select s.Id, s.Name, from Stations s;", con))
           using (SqlDataReader rdr = com.ExecuteReader())
           {
               while (rdr.Read())
               {
                    int id = (Int32)rdr[0];
                    string name = (string)rdr[1];
    
                    st.Add(new Station(name, id));
               }
           }
        }
        return st;
    }
