    public void CallOtherMethodMethodGroup(Action action)
    {
        MethodInfo method = action.Method;
        //check that 'action' is not a compiler generated lambda
        if (!method.IsDefined(typeof (CompilerGeneratedAttribute)))
        {
            Console.WriteLine(method.Name);
        }
        else
            throw new InvalidOperationException("Use 'CallOtherMethodExpr' instead.");
    }
