    public class Telegram<T>
    {
        T additionalInfo;
        Telegram(double time, int otherSender, int otherReceiver,
                Message otherMessage, T info = null)
        where T : class
