    [InvalidOperationException: The dependency resolver is not of type 'Autofac.Integration.Mvc.AutofacDependencyResolver' and does not appear to be wrapped using DynamicProxy from the Castle Project. This issue could be the result of a change in the DynamicProxy implementation or the use of a different proxy library to wrap the dependency resolver.]
       Autofac.Integration.Mvc.AutofacDependencyResolver.get_Current() +367
       Autofac.Integration.Mvc.AutofacFilterProvider.GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor) +196
       System.Web.Mvc.FilterProviderCollection.GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor) +279
       System.Web.Mvc.ControllerActionInvoker.GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor) +62
       System.Web.Mvc.Async.AsyncControllerActionInvoker.BeginInvokeAction(ControllerContext controllerContext, String actionName, AsyncCallback callback, Object state) +436
       System.Web.Mvc.Controller.<BeginExecuteCore>b__1c(AsyncCallback asyncCallback, Object asyncState, ExecuteCoreState innerState) +82
       System.Web.Mvc.Async.WrappedAsyncVoid`1.CallBeginDelegate(AsyncCallback callback, Object callbackState) +73
       System.Web.Mvc.Async.WrappedAsyncResultBase`1.Begin(AsyncCallback callback, Object state, Int32 timeout) +151
       System.Web.Mvc.Async.AsyncResultWrapper.Begin(AsyncCallback callback, Object callbackState, BeginInvokeDelegate`1 beginDelegate, EndInvokeVoidDelegate`1 endDelegate, TState invokeState, Object tag, Int32 timeout, SynchronizationContext callbackSyncContext) +105
       System.Web.Mvc.Controller.BeginExecuteCore(AsyncCallback callback, Object state) +588
       System.Web.Mvc.Controller.<BeginExecute>b__14(AsyncCallback asyncCallback, Object callbackState, Controller controller) +47
       System.Web.Mvc.Async.WrappedAsyncVoid`1.CallBeginDelegate(AsyncCallback callback, Object callbackState) +65
       System.Web.Mvc.Async.WrappedAsyncResultBase`1.Begin(AsyncCallback callback, Object state, Int32 timeout) +151
       System.Web.Mvc.Async.AsyncResultWrapper.Begin(AsyncCallback callback, Object callbackState, BeginInvokeDelegate`1 beginDelegate, EndInvokeVoidDelegate`1 endDelegate, TState invokeState, Object tag, Int32 timeout, SynchronizationContext callbackSyncContext) +139
       System.Web.Mvc.Controller.BeginExecute(RequestContext requestContext, AsyncCallback callback, Object state) +484
       System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.BeginExecute(RequestContext requestContext, AsyncCallback callback, Object state) +50
       System.Web.Mvc.MvcHandler.<BeginProcessRequest>b__4(AsyncCallback asyncCallback, Object asyncState, ProcessRequestState innerState) +98
       System.Web.Mvc.Async.WrappedAsyncVoid`1.CallBeginDelegate(AsyncCallback callback, Object callbackState) +73
       System.Web.Mvc.Async.WrappedAsyncResultBase`1.Begin(AsyncCallback callback, Object state, Int32 timeout) +151
       System.Web.Mvc.Async.AsyncResultWrapper.Begin(AsyncCallback callback, Object callbackState, BeginInvokeDelegate`1 beginDelegate, EndInvokeVoidDelegate`1 endDelegate, TState invokeState, Object tag, Int32 timeout, SynchronizationContext callbackSyncContext) +106
       System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, Object state) +446
       System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContext httpContext, AsyncCallback callback, Object state) +88
       System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData) +50
       System.Web.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute() +301
       System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously) +155
