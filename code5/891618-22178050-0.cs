    public interface IDevice
    {
    
    }
    
    class vJoystick : Joystick, IDevice
    {
        public vJoystick(DirectInput di, Guid g) : base(di, g) {}
    }
    
    class vMouse : Mouse, IDevice
    {
        public vMouse( DirectInput di ) : base(di) { }
    }
    
    public class DeviceFactory
    {
        public static IDevice Create( object device, DirectInput di, Guid g )
        {
            if ( device is Joystick ) return new vJoystick(di, g);
            if ( device is Mouse )    return new vMouse(di);
            return new vJoystick(di, g);//defult
        }
    }
