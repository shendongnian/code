      protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }
    
                WebViewPage webViewPage = instance as WebViewPage;
                if (webViewPage == null)
                {
                    throw new InvalidOperationException(
                        String.Format(
                            CultureInfo.CurrentCulture,
                            MvcResources.CshtmlView_WrongViewBase,
                            ViewPath));
                }
