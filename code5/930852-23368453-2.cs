    public interface IOhmioService
    {        
      [OperationContract]
      IEnumerable<Enumerador> GetEnumerador(string typeName);       
    }
    public class OhmioService : IOhmioService
    {
      public IEnumerable<Enumerador> GetEnumerador(string typeName)
      {
          var type = Type.GetType(typeName);
          var _obj = (IEnumerador)Activator.CreateInstance(type);
          return _obj.Enumerar();  
      }
    }
