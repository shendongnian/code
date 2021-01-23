    public interface IOhmioService
    {        
      [OperationContract]
      IEnumerable<Enumerador> GetEnumerador(Type type);       
    }
    public class OhmioService : IOhmioService
    {
      public IEnumerable<Enumerador> GetEnumerador(Type type)
      {
          var _obj = (IEnumerador)Activator.CreateInstance(type);
          return _obj.Enumerar();  
      }
    }
