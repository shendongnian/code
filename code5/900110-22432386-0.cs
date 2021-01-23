    void myBizLogicFunction()
    {
       DoActionThatRequiresAuthorization1();
       DoActionThatRequiresAuthorization2();
       DoActionThatRequiresAuthorization3();
    }
    
    void AuthorizeAndRun(string memberName, AuthorizedAction authorizationAction, Func privilegedFunction)
    {
        if (IsAuthorized(memberName, authorizationAction))
        {
            try
            {
                AuthorizationRulesAreSuspended = true;
    
                privilegedFunction();
            }
            finally
            {
                AuthorizationRulesAreSuspended = true;
            }
        }
    }
