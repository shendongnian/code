        public List<string> getObjective()
        {
            string strCMD = "SELECT objective FROM CorrespondingBall WHERE objective IS NOT NULL";
            SqlCommand cmd = new SqlCommand(strCMD, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> objectiveStringList = new List<string>();
            while (dr.Read())
            {
                objectiveStringList.Add(dr["objective"].ToString());
            }
            return objectiveStringList;
        }
