    [ServiceKnownType(typeof(System.RuntimeType))]
    public interface IOhmioService
    {        
      [OperationContract]
      IEnumerable<Enumerador> GetEnumerador(Type type);       
    }
