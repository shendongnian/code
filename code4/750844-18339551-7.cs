    public class PersonChoiceHandler : ICallHandler
    {
        private WriteOption writeOption;
    
        private PersonChoice personChoice;
    
        public PersonChoiceHandler(WriteOption writeOption)
        {
            this.writeOption = writeOption;
        }
    
        public PersonChoiceHandler()
        {
            this.writeOption = WriteOption.Both;
        }
    
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            // Get personChoice value from object property.
            personChoice = (PersonChoice)Enum.Parse(typeof(PersonChoice),  input.Target.GetType().GetProperty("PersonChoice").GetValue(input.Target, null).ToString());
            
            // Get Method Name and parameters
            string methodName = input.MethodBase.Name;
            object[] methodArgs = new object[input.Inputs.Count];
            for (int i = 0; i < input.Inputs.Count; i++)
            {
                methodArgs[i] = input.Inputs[i];
            }
    
            Type firstPersonType = null;
            Type secondPersonType = null;
            object firstPersonObject;
            object secondPersonObject;
    
            // based on personChoice value, instantiate appropriate class and execute the appropriate method .
            switch (personChoice)
            {
                case PersonChoice.Peter:
                    firstPersonType = typeof(TestClassPeter);
                    break;
                case PersonChoice.Charles:
                    firstPersonType = typeof(TestClassCharles);
                    break;
                case PersonChoice.Both:
                    firstPersonType = typeof(TestClassPeter);
                    secondPersonType = typeof(TestClassCharles);
                    break;
                default:
                    break;
            }
    
    
            // object is instantiated with default constructor. No need to specify PersonChoice property.
            firstPersonObject = Activator.CreateInstance(firstPersonType);
            if (personChoice == PersonChoice.Both)
            {
                secondPersonObject = Activator.CreateInstance(secondPersonType);
            }
            else
            {
                secondPersonObject = null; ;
            }
    
            // decide method invocation based on PersonChoice
            object firstReturnValue;
            object secondReturnValue;
            switch (personChoice)
            {
                // Call Peter's or Charles' methods
                case PersonChoice.Peter : case PersonChoice.Charles:
                    firstReturnValue = firstPersonType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, firstPersonObject, methodArgs);
                    break;
    
                // Call Method on Both Peter and Charles and combine results
                case PersonChoice.Both :
                    firstReturnValue = firstPersonType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, firstPersonObject, methodArgs);
                    secondReturnValue = secondPersonType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, secondPersonObject, methodArgs);
    
                    // build return value. Done here checking method name as an example.
                    if (methodName == "NamePlusLastName")
                    {
                        string returnValue = (string)firstReturnValue;
                        firstReturnValue = returnValue + (string)secondReturnValue;
                    }
                    else
                    {
                        int returnValue = (int)firstReturnValue;
                        firstReturnValue = returnValue + (int)secondReturnValue;
                    }
    
                    break;
    
                default:
                    firstReturnValue = firstPersonType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, firstPersonObject, methodArgs);
                    break;
            }
    
            // Override initial method execution
            IMethodReturn methodReturn = new VirtualMethodReturn(input, null);
    
            // this down here would have called the original method.
            //var methodReturn = getNext().Invoke(input, getNext);
    
            // Set the return value
            methodReturn.ReturnValue = firstReturnValue;
    
            return methodReturn;
    
        }
    
        public int Order { get; set; }
    }
