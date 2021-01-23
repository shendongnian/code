    public static class Extensions
    {
        public static string GetCdnStreamingUriFor(this Model[] input, string name)
        {
            foreach (var model in input)
            {
                if (model.Name == name)
                    return model.CdnStreamingUri;
            }
    
            return string.Empty;
        }
    }
