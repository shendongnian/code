            DataTable dataTableTmp = new DataTable();
            dataTableTmp.Columns.Add("ID_USER", typeof(Int32));
            dataTableTmp.Columns.Add("ID_DATA", typeof(Int32));
            dataTableTmp.Columns.Add("HEADER_TXT", typeof(string));
            foreach (var r in DomandeRisposteList)
            {
                DataRow ro = dataTableTmp.NewRow();
                ro[0] = r.IdUser;
                ro[1] = r.IdData ;
                ro[2] = r.HeaderTxt ;
                dataTableTmp.Rows.Add(ro);
            }
            var dbConn = dbFactory.OpenDbConnection();
            var res = dbConn.Exec(dbCmd =>
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@LISTA_QUESTIONARIO", dataTableTmp));
                dbCmd.CommandText = "IF_SP_QUESTIONARIO_MIFID_QUESTIONARIO_INSERT_TEST";
                return dbCmd.ExecuteReader().ConvertToList<DomandeRisposteItem>(); 
            });
            return res;
