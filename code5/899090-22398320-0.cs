    public void method1(DataTable ServerGroupIds)
    {
       
       string [] serverGroups = ServerGroupIds.AsEnumerable().Select(t => t.Field<string>("ID")).ToArray<string>();
    obj.method2(serverGroups );  
    
    }
