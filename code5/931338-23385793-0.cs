    public static class LocalizationHelper {
    	public static string View1_Question {
    		get { return Resource.ResourceManager.GetString("View1_Question", CultureInfo.GetCultureInfoByIetfLanguageTag(Config.Language)); }
    	}
    }
    
    var q1 = LocalizationHelper.View1_Question;
