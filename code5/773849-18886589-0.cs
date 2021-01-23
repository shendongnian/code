    public List<GSP> GetOwnAirline()
        {
            string get_ = "SELECT * FROM " + Adm.schema_ + "Adm.GSP WHERE Description = 'Own Airline'";
            ccs = new SqlConnection(Adm.COnnectionString);
            //convey transaction to db
            cmd = ccs.CreateCommand();
            ccs.Open();
            cmd.CommandText = get_;
            var res =cmd.ExecuteScalar();
            ccs.Close();
            List<GSP> gsp = new List<GSP>();
            GSP temp = new GSP();
            temp.PropertyName = res;
            gsp.Add(temp);
            return gsp;
        }
