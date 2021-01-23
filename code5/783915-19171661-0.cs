     public interface ICommonEvents
    {
        void BroadcastMessage(string text);
    }
    public class CommonEvents : ICommonEvents
    {
        public void BroadcastMessage(string text)
        {
        }
    }
