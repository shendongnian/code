    sqlWrite.BindByName = true;
                    var blobparameter = new OracleParameter
                    {
                        OracleDbType = OracleDbType.Blob,
                        ParameterName = "ssfile",
                        Value = fileToPut.ToArray()
                    };
                    sqlWrite.Parameters.Add(blobparameter);
