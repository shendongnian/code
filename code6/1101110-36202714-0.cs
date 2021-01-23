    public static string GetDictionaryValue(string key, CultureInfo culture, UmbracoContext context)
    {
        var dictionaryItem = context.Application.Services.LocalizationService.GetDictionaryItemByKey(key);
        if (dictionaryItem != null)
        {
            var translation = dictionaryItem.Translations.SingleOrDefault(x => x.Language.CultureInfo.Equals(culture));
            if (translation != null)
                return translation.Value;
        }
        return key; // if not found, return key
    }
