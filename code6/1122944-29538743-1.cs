    public static class SubscriptionBindingExtensions
    {
        public static void BindConsumer<T>(this IBindingRoot bindingRoot)
            where T : IConsumer
        {
            Bind<SubscriptionMetadata>()
              .ToConstant(new SubscriptionMetadata(typeof(T));
        }
    }
