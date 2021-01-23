    public interface IOhmioService
    {        
      [OperationContract]
      IEnumerable<Enumerador> GetEnumerador(RuntimeType type);       
    }
