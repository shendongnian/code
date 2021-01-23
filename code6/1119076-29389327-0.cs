    public class ViewModel {
      public IHtmlString ToJson() {
        return ToJson(new CamelCasePropertyNamesContractResolver());
      } // ToJson
      public IHtmlString ToJson(IContractResolver resolver) {
        JsonSerializerSettings settings = new JsonSerializerSettings {
          ContractResolver = resolver 
        };
        return MvcHtmlString.Create(JsonConvert.SerializeObject(this, settings));
      } // ToJson
    } // ViewModel 
