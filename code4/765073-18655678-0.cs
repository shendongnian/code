    public class RenderManager
    {
        public void Render(IPage page, Renderer renderer)
        {
            try
            {
                renderer.RenderPage((dynamic)page);
            }
            catch (RuntimeBinderException ex)
            {
                throw new Exception("Page type not supported", ex);
            }
        }
    }
