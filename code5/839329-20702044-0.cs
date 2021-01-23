        class Class2 : Class1
        {
            public override string MethodWithOptParams(string message = "default message")
            {
                return base.MethodWithOptParams(message);
            }
        }
        
        class Class1
        {
            public virtual string MethodWithOptParams([Optional]string message)
            {
                return message;
            }
        }
