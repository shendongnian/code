    public TestFilterAttribute() {
        // Instance will be reused thus this will not be called for each Action
    }
    public override void OnActionExecuting(HttpActionContext actionContext) {
        // Called on each Action
    }
