    public interface IOhmioService
    {        
      [OperationContract]
      IEnumerable<Enumerador> GetEnumerador(Type type);       
    }
    public class OhmioService : IOhmioService
    {
      public IEnumerable<Enumerador> GetEnumerador(Type type)
      {
          dynamic _obj = Activator.CreateInstance(type);
          return (IEnumerable<Enumerador>)_obj.Enumerar();  
      }
    }
