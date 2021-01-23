                using (Stream stm = req.GetRequestStream())
                {
                    using (StreamWriter stmw = new StreamWriter(stm))
                    {
                         foreach (string gamme in listGamme)
                            {
                                 stmw.Write(gamme);
                             }   
                     }
                }
    WebResponse response = req.GetResponse();
        StreamReader srreader = new StreamReader(response.GetResponseStream());
