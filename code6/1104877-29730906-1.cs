    @foreach (var item in Model)
        {
            <li>
                @item.Name
                <ul>
                    @foreach (var action in item.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(method => typeof(ActionResult).IsAssignableFrom(method.ReturnType)))
                    {
                        try
                        {
                            <li>@action.CustomAttributes.SingleOrDefault(m => m.AttributeType.Name == "DisplayAttribute").NamedArguments.ElementAt(0).TypedValue</li>
                        }
                        catch(NullReferenceException){}
                            
                        
                        
                    }
                </ul>
    
            </li>
        }
