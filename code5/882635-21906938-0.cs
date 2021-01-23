    public override bool Equals(object obj)
    {
        // this statement CAN FAIL if your "obj" is *NOT* of type "Parameter"
        var par = obj as Parameter;
        // so therefore you MUST be ready to deal with a NULL value here!
        if (par != null && ParameterName == par.ParameterName)  
        {
            return true;
        }
        else
        {
            return false;
        }
    
    }
