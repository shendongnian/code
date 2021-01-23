    var NewLanguage = (string)((ComboBoxItem)e.AddedItems[0]).Tag;
    
    Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = NewLanguage;
    
    Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
    //Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
    
    Windows.ApplicationModel.Resources.Core.ResourceManager.Current.DefaultContext.Reset();
