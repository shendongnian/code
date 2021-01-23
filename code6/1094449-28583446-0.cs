    interface IResourceProperties
    {
    }
    interface IDevice<out T>
        where T : IResourceProperties
    {
    }
    class TopLevelResource<T>
        where T : IResourceProperties
    {
    }
    class Camera : TopLevelResource<CameraProperties>, IDevice<CameraProperties>
    {
    }
    class CameraProperties : IResourceProperties
    {
    }
    class Phone : TopLevelResource<PhoneProperties>, IDevice<CameraProperties>
    {
    }
    class PhoneProperties : IResourceProperties
    {
    }
    internal class Runner
    {
        public static void Run()
        {
            List<Camera> cameras = new List<Camera>();
            List<Phone> phones = new List<Phone>();
            DoSomething(cameras);
            DoSomething(phones);
        }
        static void DoSomething<T>(List<T> items)
            where T : IDevice<IResourceProperties>
        {
            return;
        }
    }
