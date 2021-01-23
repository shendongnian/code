           public DNNLoginResponse LoginCloudUser(DNNLogin args)
          {
            try
            {
    
                bool validateresult = DNNLogin.ValidateUser(args); 
                DNNLoginResponse dlogres = new DNNLoginResponse();
                if (validateresult)
                {
                    dlogres.result = validateresult;
                    dlogres.resulttype =  "Success" ;
                    dlogres.userid = args.username;
                }
                else
                {
                    dlogres.result = validateresult;
                    dlogres.resulttype = "Login Error";
                    dlogres.userid = string.Empty;
                   
                }
           
                return dlogres; //JsonConvert.SerializeObject(dlogres, Formatting.None, jss); 
            }
            catch
            { 
                DNNLoginResponse dlogres = new DNNLoginResponse(); 
                dlogres.result = false;
                dlogres.resulttype = "Internal Error";
                dlogres.userid = string.Empty;
                return dlogres;  
            }
        }
