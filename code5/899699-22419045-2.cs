    public enum RemoteButtons
    {
        Play,
        Pause,
        Stop
    }
    public class RemoteControl
    {
        public bool Push(RemoteButtons button)
        {
            Console.WriteLine(button.ToString());
            return true;
        }
    }
