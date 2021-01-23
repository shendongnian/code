    System.Text.Encoding Enc = System.Text.Encoding.GetEncoding(response.CharacterSet);
    StreamReader sr = new StreamReader(response.GetResponseStream(), Enc); 
    string sDoc = sr.ReadToEnd();               
    sr.Close();            
    byte[] by = Encoding.ASCII.GetBytes(sDoc);
