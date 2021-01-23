    public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result;
            // Taking care of implementation of additional interface IWhatever.
            if (input.MethodBase.DeclaringType == typeof (IWhatever))
            {
                switch (input.MethodBase.Name)
                {
                    case "get_Name":
                        // Do your stuff here
                        // Make sure you do this to get rid of your exception.
                        // Pass the argument so that the calling code gets it.
                        result = input.CreateMethodReturn(input.Arguments[0]);
                        break;
                    default:
                        result = input.CreateMethodReturn(null);
                        break;
                }
            }
            else
            {
                // Do other stuff here.
                result = getNext()(input, getNext);
            }
            return result;
        }
