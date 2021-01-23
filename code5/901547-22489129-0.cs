            Uri uri = new Uri("/file.xml", UriKind.Relative);
            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info != null)
            {
                using (StreamReader reader = new StreamReader(info.Stream))
                {
                    string xml = reader.ReadToEnd();
                }
            }
