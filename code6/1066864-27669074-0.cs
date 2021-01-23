    public class Tasks
    {
        public const EventTask Connect = (EventTask)0x1;
    }
    [EventSource(Name = "kafka4net")]
    public sealed class ConnectionTrace : EventSource
    {
        public static ConnectionTrace Log = new ConnectionTrace();
        [Event(1, Task = Tasks.Connect, Opcode = EventOpcode.Start)]
        public void Connecting(string host, int port)
        {
            if (Log.IsEnabled())
            {
                Log.WriteEvent(1, host, port);
            }
        }
        [Event(2, Task = Tasks.Connect, Opcode = EventOpcode.Stop)]
        public void Connected(string host, int port)
        {
            if (Log.IsEnabled())
            {
                Log.WriteEvent(2, host, port);
            }
        }
    }
