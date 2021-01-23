        void AddResourceDictionary(string source)
        {
            ResourceDictionary resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
