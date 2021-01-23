public static class HtmlHelperExtensions
{
    public static BeginFormObject<T> BeginForm<T>(this HtmlHelpers<T> helpers, NancyRazorViewBase<T> view)
    {
        return new BeginFormObject<T>("&lt;form method=\"post\"&gt;", view);
    }
    public class BeginFormObject<T> : IDisposable
    {
        private NancyRazorViewBase<T> view;
        public BeginFormObject(string markup, NancyRazorViewBase<T> view)
        {
            this.view = view;
            view.WriteLiteral(markup);
        }
        public void Dispose()
        {
            view.WriteLiteral("&lt;/form&gt;");
        }
    }
}
