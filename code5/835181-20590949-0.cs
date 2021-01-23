                if (!FirstRun)
                {
                    ClientsData.Add(new MapModel.ClientInfo 
                    { Id = IDCounter, 
                      ClientID = Reader["ClientID"].ToString(), 
                      //.
                      //. removing code just to make my answer shorter
                      //. 
                      DocNames = { }  // this is the problem. DocNames is null.
                    });
                    
                    FirstRun = true;
                 }
