    public interface ISmartSheetProvider
    {
        string GetJsonData();
    }
    public class ProductionSmartSheetProvider : ISmartSheetProvider
    {
        public string GetJsonData()
        {
            return new SmartsheetQuery().getJsonAsString("GLHTanneryData_CurrentWeek"));
        }
    }
    public class MockSmartSheetProvider : ISmartSheetProvider
    {
        public string GetJsonData()
        {    
            return "..."; // whatever test data.
        }
    }
    public class JsonQuery(ISmartSheetProvider smartSheetProvider)
    {
        jObject = jObject.Parse(smartSheetProvider.GetJsonData());
    }
