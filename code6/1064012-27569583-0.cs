      public static string Localize(string key)
      {
           try
           {
               var netLanguage = Locale();
               ResourceManager temp = new ResourceManager("MyApp.Strings.AppResources", typeof(Translator).GetTypeInfo().Assembly);
               string result = temp.GetString(key, new CultureInfo(netLanguage));
    
               return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
