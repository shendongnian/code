    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
        public class pwGateInternalService : IpwGateInternalService
        {
            static List<SchoolCallback> m_schools = new List<SchoolCallback>();
    
            //non contract Functions:
    
            public List<SchoolCallback> GetClientList()
            {
                return m_schools;
            }
            
            //Contract Functions:
            
            public ServiceStatus Connect(string schoolname)
            {
                ServiceStatus result = new ServiceStatus();
                int schoolid = Config.GetIdentifier(schoolname);
    
                //add to dynamic list of schools
                IpwGateInternalCallback callback = OperationContext.Current.GetCallbackChannel<IpwGateInternalCallback>();
                if (m_schools.Find(x => x.callback == callback) == null)
                {
                    SchoolCallback school = new SchoolCallback(schoolid, schoolname, callback);
                    m_schools.Add(school);
    
                    result.status = eStatus.success;
                }
                else
                {
                    //already found
                    result.status = eStatus.error;
                    result.strError = "a client with your name is already connected";
    
                    //TODO
                    //mail?
                }
                return null;
            }
    
            public void Disconnect()
            { 
                //remove from dynamic list
                IpwGateInternalCallback callback = OperationContext.Current.GetCallbackChannel<IpwGateInternalCallback>();
                SchoolCallback school = m_schools.Find(x => x.callback == callback);
                if (school != null)
                {
                    m_schools.Remove(school);
                }
                
            
            }//Disconnect()
        }//callback interface
