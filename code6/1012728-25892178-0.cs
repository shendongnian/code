    public ActionResult NamiaryWyZapis()
    {                
                    Stream jsonDane = Request.InputStream;
                    jsonDane.Seek(0, System.IO.SeekOrigin.Begin);
    
                    string json = new StreamReader(jsonDane).ReadToEnd();
    //--
    }
