    public class DataOutputStream
    {
        // await and actions will be executed in given order, non-blocking
        public Task Execute(Action action)
        {
            return Task.Run(action);
        }
        // fire & forget, non-blocking
        public void BeginInvoke(Action action)
        {
            action.BeginInvoke(callback => {}, null);
        }
        // blocking
        public void Invoke(Action action)
        {
            action.Invoke();
        }
        public void WriteInt(int integer)
        {
            Debug.WriteLine("int:{0}", integer);
        }
    }
