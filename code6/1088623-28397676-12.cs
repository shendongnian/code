    public sealed class MessageDispatcher
    {
        public static void DispatchMessage<T>(double delay, int sender,
                                int otherReceiver, Message message,
                                T additionalInfo = default(T))
       ...
    }
