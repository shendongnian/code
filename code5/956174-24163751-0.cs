        string result = string.Empty;
    
           try
           {
            // code here 
              Lidoc_num = com1.Parameters[0].Value.ToString();
              result = Lidoc_num;
           }
        catch (OracleException ex)
                {
                    if (ora_trn != null) ora_trn.Rollback();
        
                    if (ora_cn != null)
                        if (ora_cn.State != ConnectionState.Closed)
                            ora_cn.Close();
        
                    WriteErrors.WriteToLogFile("Dohvati_IDOC", "Greška:" + ex.ToString());
        
                    result = "";
                }
    
    return result;
