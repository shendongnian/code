    [WebMethod]
    public object Method(params object[] parameters)
    {
        object returnValue = null;
        if (parameters != null && parameters.Length != 0)
        { 
            if (parameters[0].GetType() == typeof(string) && parameters[1].GetType() == typeof(int))
            {
                return new ServiceImplementation().StringIntMethod(parameters[0].ToString(), Convert.ToInt32(parameters[1]));
            }
            else if (parameters[0].GetType() == typeof(string) && parameters[1].GetType() == typeof(string))
            {
                return new ServiceImplementation2().StringStringMethod(parameters[0].ToString(), parameters[1].ToString());
            }
        }
        return returnValue;
    }
