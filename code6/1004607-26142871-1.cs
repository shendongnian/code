    protected void Page_Load(object sender, EventArgs e) 
    {
        InitiatePage();
    }
    
    private void InitiatePage()
    {
        var queryString = Request.QueryString;
    
        var pageMethodObject = queryString["PageMethod"];
        if (pageMethodObject != null)
        {
            string methodName = pageMethodObject.ToString();
    
            Type ty = this.GetType().BaseType;
    
            MethodInfo methodInfo = ty.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
    
            if (methodInfo != null)
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
    
                if (parameters.Length == 0)
                {
                    methodInfo.Invoke(this, null);
                }
                else
                {
                    IList<object> parametersArray = new List<object>();
    
                    foreach (var parameter in parameters)
                    {
                        var value = queryString[parameter.Name];
                        object obj = null;
                        if (parameter.ParameterType.IsEnum)
                        {
                            obj = Enum.Parse(parameter.ParameterType, value);
                        }
                        else
                        {
                            obj = Convert.ChangeType(value, parameter.ParameterType);
                        }
                        parametersArray.Add(obj);
                    }
    
                    //try and run the method
                    methodInfo.Invoke(this, parametersArray.ToArray());
                }
            }
        }
    }
