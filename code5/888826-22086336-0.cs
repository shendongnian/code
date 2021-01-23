    protected void readSession()
        {
            var output = (Interrogation)Session["people1"];
                    
            foreach(var skipped in output.skipped)
            {
               Debug.WriteLine(skipped);
            }
    
            foreach(var asked in output.asked)
            {
               Debug.WriteLine(asked);
            }
        }
