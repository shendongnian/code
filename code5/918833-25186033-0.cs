        public static Geometry PathMarkupToGeometry(string pathMarkup)
        {
            try
            {
                string xaml =
                "<Path " +
                "xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" +
                "<Path.Data>" + pathMarkup + "</Path.Data></Path>";
                var path = XamlReader.Load(xaml) as Path;
                // Detach the PathGeometry from the Path
                if (path != null)
                {
                    Geometry geometry = path.Data;
                    path.Data = null;
                    return geometry;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }
