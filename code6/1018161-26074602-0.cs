    class LanguageCode
    {
        string Name { get; set; },
        string CodeName { get; set; }
    }
    
    var langs = new List<LanguageCode>();
    langs.Add(new LanguageCode() { Name = "Deutsch", CodeName = "de-DE" });
    langs.Add(new LanguageCode() { Name = "English", CodeName = "en-US" });
    //    ... and so on ...
    
    settings_language_cb.Items.Add(langs);
    settings_language_cb.SelectedItem = ""; // yet missing, don't know how to show it
