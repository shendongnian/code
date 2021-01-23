    public bool DSNExists(string dsnName)
        {
            try
            {
                var sourcesKey = Registry.LocalMachine.OpenSubKey(this.ODBC_INI_REG_PATH + "ODBC Data Sources");
                if (sourcesKey == null)
                {
                    throw new Exception("ODBC Registry key for sources does not exist");
                }
                string[] blah = sourcesKey.GetValueNames();
                Console.WriteLine("length: " + blah.Length); //prints: 0
                return sourcesKey.GetValue(dsnName) != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
