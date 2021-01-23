    class Child
        {
            public void Method()
            {
                StackFrame sf = new StackFrame(1);
                var type = sf.GetMethod().ReflectedType;
    
                var field = type.GetFields().FirstOrDefault(i => i.FieldType == typeof(Child));
    
                Log(field.Name);
            }
        }
