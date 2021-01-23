    public class NotificationUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Registering += (sender, args) =>
            {
                // Called when type is registered
                Console.WriteLine($"Registering type {args.TypeTo.Name}");
            };
            Context.RegisteringInstance += (sender, args) =>
            {
                // Called when instance is registered
                Console.WriteLine($"Registering instance of type {args.Instance.GetType().Name}");
            };
        }
    }
