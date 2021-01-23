      OleDbConnection con = new OleDbConnection("Provider=IBMDADB2.DB2COPY1; DATA SOURCE=SAMPLE;UID=UID;PWD=PWD");
    
      OleDbConnection mysqlcon2 = new OleDbConnection("Provider=ADsDSOObject; DATA SOURCE=SAMPLE;UID=UID;PWD=PWD");
                    con.Open();
                    mysqlcon2.Open();
