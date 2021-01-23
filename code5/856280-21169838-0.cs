        public Dictionary<int, List<int>> GetAllLists(string sGuid)
        {
            Dictionary<int, List<int>> lRespondents = new Dictionary<int, List<int>>();
            SqlConnection sqlCon = new SqlConnection(sqlConnString);
            StringBuilder sSQL = new StringBuilder();
            sSQL.Append("SELECT Demographic_Answers.ID FROM Demographic_Answers ");
            sSQL.Append("LEFT JOIN Demographic_Questions ON Demographic_Answers.Demogrpahic_ID = Demographic_Questions.ID ");
            sSQL.Append("WHERE Demographic_Questions.Survey_ID = '" + sGuid + "' ");
            SqlCommand sqlCom = new SqlCommand(sSQL.ToString());
            sqlCom.Connection = sqlCon;
            sqlCon.Open();
            int iKeyName = 0;
            try
            {
                SqlDataReader sqlDR = sqlCom.ExecuteReader();
                while (sqlDR.Read())
                {
                    iKeyName = sqlDR.GetInt32(0);
                    List<int> sub = new List<int>(); //Dynamic Name here sub = sqlDR.GetInt32(0).ToString
                    sub = getRespondentList(sqlDR.GetInt32(0).ToString()); // Dynamic Name here. Sub should = sqlDR.GetInt32(0).ToString
                    lRespondents.Add(iKeyName, sub);
                }
            }
            catch
            {
            }
            finally
            {
                sqlCon.Close();
            }
            return lRespondents;
        }
