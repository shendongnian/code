    class ErrorHolder<T> // T would be AError, BError
    {
       T ErrorCode {get;}
       object[] InnerErrors {get;}
       // other payload could go here like inner exceptions etc.
    }
