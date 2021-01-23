       cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter inputParameter = new OracleParameter();
                inputParameter.OracleDbType = OracleDbType.Int32;
                inputParameter.Direction = ParameterDirection.Input;
                inputParameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                inputParameter.Value = acctId.ToArray();
                cmd.Parameters.Add(inputParameter);
