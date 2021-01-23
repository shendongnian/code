    public class Car
    {
        public readonly IntPtr nativeCarObject = Sim.DLL_AddCar();
    }
    public class Wheel
    {
        public readonly IntPtr nativeWheelObject = Sim.DLL_AddWheel();
    }
    internal class Sim
    {
        public const string pluginName = "MyDLL";
        [DllImport(pluginName, CallingConvention=CallingConvention.Cdecl)]
        public static extern IntPtr DLL_AddCar();
        [DllImport(pluginName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DLL_AddWheel();
        [DllImport(pluginName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DLL_GiveWheelToCar(IntPtr car, IntPtr wheel);
    }
