    public static void ReplaceLanguage(Uri source)
        {
            //The name of the folder where the languages are contained (could be a parameter)
            string folder = "languages";
            if (source == null)
                return;
            ResourceDictionary dictionary;
            try
            {
                dictionary = (ResourceDictionary)Application.LoadComponent(source);
            }
            catch (IOException)
            {
                //resource file doesn't exist.
                return;
            }
            //Remove current resource from the merged dictionaries
            var currentResource = Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x.Source != null && x.Source.ToString().Contains(folder));
            if (currentResource != null)
                Application.Current.Resources.MergedDictionaries.Remove(currentResource);
            //Add the new resource to the dictionary
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
