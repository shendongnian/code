      interface IValuesController
      {
        string Get(int id);
      }
    
      public class ValuesController : IValuesController
      {
        public string Get(int id)
        {
          return id.ToString();
        }
      }
    
      public class ValuesControllerWithContracts : IValuesController{
      
        private IValuesController classToDecorate;
    
        ValuesControllerWithContracts(IValuesController classToDecorate){
          this.classToDecorate = classToDecorate;
        }
    
        public string Get(int id)
        {
          //decorate get property with contracts
          Contract.Requires(HttpContext.Current.Request.Headers["key"] != null);
          return classToDecorate.Get(id);
        }
    
      }
    
    
      //constrution and usage, this work like a charm with Dependecy Inyection container or Factory Patterns
      IValuesController valuesController = new ValuesController();
      IValuesController valuesControllerWithContracts = new ValuesControllerWithContracts(valuesController)
      valuesControllerWithContracts.Get(1);
