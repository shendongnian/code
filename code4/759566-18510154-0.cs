    public class MultiLanguageBundler : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            foreach (var file in response.Files)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    // "ReplaceLanguageStrings" contains the search/replace logic
                    compiled += ReplaceLanguageStrings(reader.ReadToEnd());
                    reader.Close();
                }
            }
            response.Content = compiled;
            response.ContentType = "text/javascript";
        }
    }
