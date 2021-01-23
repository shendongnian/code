        class Class2 : Class1
        {
            public override string MethodWithOptParams(string message = null)
            {
                if (message == null)
                {
                    return base.MethodWithOptParams();
                }
                else
                {
                    return base.MethodWithOptParams(message);
                }
            }
        }
        class Class1
        {
            public virtual string MethodWithOptParams(string message = "default message")
            {
                return message;
            }
        }
