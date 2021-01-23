    public class ExtendedTypedFactoryComponentSelector : DefaultTypedFactoryComponentSelector
    {
    	protected override IDictionary GetArguments(MethodInfo method, object[] arguments)
    	{
    		if (arguments == null)
    		{
    			return null;
    		}
    
    		ParameterInfo[] parameters = method.GetParameters();
    		Arguments arg = new Arguments(new IArgumentsComparer[0]);
    		for (int i = 0; i < parameters.Length; i++)
    		{
    			if (arg.Contains(parameters[i].ParameterType))
    			{
    				if (this.isFunc(method.DeclaringType))
    				{
    					throw new ArgumentException(string.Format("Factory delegate {0} has duplicated arguments of type {1}. Using generic purpose delegates with duplicated argument types is unsupported, because then it is not possible to match arguments properly. Use some custom delegate with meaningful argument names or interface based factory instead.", method.DeclaringType, parameters[i].ParameterType));
    				}
    			}
    			else
    			{
    				arg.Add(parameters[i].ParameterType, arguments[i]);
    			}
    			arg.Add(parameters[i].Name, arguments[i]);
    		}
    		return arg;
    	}
    
    	private bool isFunc(Type type)
    	{
    		return ((type.FullName != null) && type.FullName.StartsWith("System.Func"));
    	}
    }
