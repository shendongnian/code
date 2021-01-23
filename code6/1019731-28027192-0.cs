            private static string ConvertRtfToXaml(string rtfContent)
        {
            var assembly = Assembly.GetAssembly(typeof(System.Windows.FrameworkElement));
            var xamlRtfConverterType = assembly.GetType("System.Windows.Documents.XamlRtfConverter");
            var xamlRtfConverter = Activator.CreateInstance(xamlRtfConverterType, true);
            var convertRtfToXaml = xamlRtfConverterType.GetMethod("ConvertRtfToXaml", BindingFlags.Instance | BindingFlags.NonPublic);
            var xamlContent = (string)convertRtfToXaml.Invoke(xamlRtfConverter, new object[] { rtfContent });
            return xamlContent;
        }
