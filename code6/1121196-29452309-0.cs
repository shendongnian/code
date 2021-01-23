    public static byte[] ConvertHtmlToRtf(string htmlText)
            {
                var xamlText = HtmlToXamlConverter.ConvertHtmlToXaml(htmlText, false);
    
                return System.Text.Encoding.UTF8.GetBytes(ConvertXamlToRtf(xamlText));
            }
