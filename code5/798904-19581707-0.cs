    public class TransactionAttribute : ActionFilterAttribute
    {
       public override void OnActionExecuting(HttpActionContext actionContext)
       {
           // create your connection and transaction. in this example, I have the dependency resolver create an NHibernate ISession, which manages my connection and transaction. you don't have to use the dependency scope (you could, for example, stuff a connection in the request properties and retrieve it in the controller), but it's the best way to coordinate the same instance of a required service for the duration of a request
           var session = actionContext.Request.GetDependencyScope().GetService(typeof (ISession));
           // make sure to create a transaction unless there is already one active.
           if (!session.Transaction.IsActive) session.BeginTransaction();
           // now i have a valid session and transaction that will be injected into the controller and usable in the action.
       }
       public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
       {
            var session = actionExecutedContext.Request.GetDependecyScope().GetService(typeof(ISession));
            var response = actionExecutedContext.Response;
            if (actionExecutedContext.Exception == null)
            {
                var content = response.Content as ObjectContent;
                if (content != null)
                {
                    // here's the real trick; if there is content that needs to be sent to the client, we need to swap the content with an object that will clean up the connection and transaction AFTER the response is written.
                    response.Content = new TransactionObjectContent(content.ObjectType, content.Value, content.Formatter, session, content.Headers);
                }
                else
                {
                    // there is no content to send to the client, so commit and clean up immediately (in this example, the container cleans up session, so it is omitted below)
                    if (session.Transaction.IsActive) session.Transaction.Commit();
                }
            }
            else 
            {
               // an exception was encountered, so immediately rollback the transaction, let the content return unmolested, and clean up your session (in this example, the container cleans up the session for me, so I omitted it)
               if (session.Transaction.IsActive) session.Transaction.Rollback();
            }
       }
    }
