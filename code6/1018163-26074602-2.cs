    class LanguageCode
    {
        string Name { get; set; },
        string CodeName { get; set; }
    }
    
    var langs = new List<LanguageCode>();
    langs.Add(new LanguageCode() { Name = "English", CodeName = "en-US" });
    langs.Add(new LanguageCode() { Name = "Deutsch", CodeName = "de-DE" });
    //    ... and so on ...
    
    settings_language_cb.Items.Add(langs);
    settings_language_cb.SelectedIndex = 0;
