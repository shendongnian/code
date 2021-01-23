    var v = new MyClass();
	
    var memberField = v.GetType().GetField("member",
            BindingFlags.NonPublic | BindingFlags.Instance);
    
    var member = memberField.GetValue(v);
    
    // no flags necessary for a public property
    var property1Property = member.GetType().GetProperty("property1");  
    
    property1Property.SetValue(member,"test");
