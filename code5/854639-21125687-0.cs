     public class ViewDataDictionary : IDictionary<string, object>
     {
        private readonly ModelStateDictionary _modelState = new ModelStateDictionary();
     public ModelStateDictionary ModelState
     {
         get { return _modelState; }
     }
