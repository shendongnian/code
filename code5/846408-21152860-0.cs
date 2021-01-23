	public override ProblemCollection Check(Member member)
	{
		var method = member as Method;
		if (method != null)
		{
			VisitStatements(method.Body.Statements);
		}
		return Problems;
	}
	public override void VisitMethodCall(MethodCall methodCall)
	{
	    var memberBinding = methodCall.Callee as MemberBinding;
	    if (memberBinding != null)
	    {
	        var methodCalled = memberBinding.BoundMember as Method;
	        if (methodCalled != null)
	        {
	            if (methodCalled.FullName == "Some.Namespace.Field.get_Value")
	                Problems.Add(new Problem(GetResolution(), methodCall));
	        }
	    }
	    base.VisitMethodCall(methodCall);
	}
