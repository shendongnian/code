        This is how your c# code should look like. Let's discuss in chat if you have more questions.
        //change the return type to string
        [WebMethod(EnableSession = true)]
        public static string save(string HTML, string Fname) 
        {            
        
        ....
    
        try
        {
            ....
            if (string.IsNullOrEmpty(tempUser))
            {
                tempUser = "0";
                return "some value 1";
             }
    
            ....
            con.Close();  
            return "some value 2";
        }
        catch (Exception ex)
        {
            CommonBLL.WriteExceptionLog(ex, "Form Save Default.aspx");
            throw ex;
        }        
    }
