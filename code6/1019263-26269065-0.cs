    async Task<bool> GetWebPages(WebView webView, Windows.Foundation.Size page)
    {
        // how many pages will there be?
        var _Scale = page.Width / webView.Width; // now sourced directly from webview
        var _ScaledHeight = (webView.Height * _Scale); // now sourced directly from webview
        var _PageCount = (double)_ScaledHeight / page.Height;
        _PageCount = _PageCount + ((_PageCount > (int)_PageCount) ? 1 : 0);
    
        var _Brush = GetWebViewBrush(webView);
    
        for (int i = 0; i < (int)_PageCount; i++)
        {
            var _TranslateY = -page.Height * i;
            // You can probably optimize this bit
            _RenderSource.Height = page.Height;
            _RenderSource.Width = page.Width;
            Margin = new Thickness(5);
    
            _Brush.Stretch = Stretch.UniformToFill;
            _Brush.AlignmentY = AlignmentY.Top;
            _Brush.Transform = new TranslateTransform { Y = _TranslateY };
            _RenderSource.Fill = _Brush;
    
            RenderTargetBitmap rtb = new RenderTargetBitmap();
    
            await rtb.RenderAsync(_RenderSource);
    
            var _iPge = new Image
            {
                Source = rtb,
                Margin = new Thickness(10)
            };
    
            _Pages.Add(_iPge);
        }
        return true;
    }
