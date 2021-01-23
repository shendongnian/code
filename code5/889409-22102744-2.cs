    public class DeviceFactory
    {
        public static AgnosticDevice Create(string someInput)
        {
            if (someInput == "something")
            {
                return new Mouse();
            }
            return new Joystick();
        }
    }
