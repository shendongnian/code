    public static class IViewExtensions
    {
        public static string GetViewName(this IView view)
        {
            string viewUrl = String.Empty;
            if (view is BuildManagerCompiledView)
            {
                viewUrl = ((BuildManagerCompiledView)view).ViewPath;
            }
            else
            {
                throw new InvalidOperationException("Buld manager is not defined!");
            }
            string viewFileName = viewUrl.Substring(viewUrl.LastIndexOf('/'));
            string viewFileNameWithoutExtension = Path.GetFileNameWithoutExtension(viewFileName);
            return (viewFileNameWithoutExtension);
        }
    }
