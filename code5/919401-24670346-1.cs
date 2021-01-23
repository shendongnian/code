    public class FixedAsyncRenderMvcController : RenderMvcController
    {
        public FixedAsyncRenderMvcController()
        {
            this.ActionInvoker = new FixedAsyncRenderActionInvoker();
        }
    }
