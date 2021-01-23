    public object BeforeCall(string operationName, object[] inputs)
            {
                if (UserAuthenticToken.IsValidUser())
                    return null;
                else
                {                    
                    throw new FaultException("User is not authenticated.");
                }
            }
