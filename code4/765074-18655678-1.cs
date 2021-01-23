    public interface IPage
    {
        void Render(Renderer renderer);
    }
    public class StaticPage : IStaticPage
    {
        public void Render(Renderer renderer)
        {
            renderer.RenderPage(this);
        }
    }
    public class RenderManager
    {
        public void Render(IPage page, Renderer renderer)
        {
            page.Render(renderer);
        }
    }
