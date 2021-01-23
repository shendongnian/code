        public static HtmlHelper<T> Create<T>(T viewModel)
        {
            var vd = new ViewDataDictionary();
            vd.Model = viewModel;
            var vc = new ViewContext {HttpContext = new FakeHttpContext(), ViewData = vd};
            var html = new HtmlHelper<T>(vc, new FakeViewDataContainer());
            return html;
        }
