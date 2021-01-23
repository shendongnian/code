        class Class2 : Class1
        {
            public override string MethodWithOptParams(string message = DefaultMessage)
            {
                return base.MethodWithOptParams(message);
            }
        }
        class Class1
        {
            protected const string DefaultMessage = "default message";
            public virtual string MethodWithOptParams(string message = DefaultMessage)
            {
                return message;
            }
        }
