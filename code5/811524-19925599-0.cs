    public static bool IsRegistered<T>(this IUnityContainer container)
    {
      Guard.ArgumentNotNull((object) container, "container");
      return UnityContainerExtensions.IsRegistered(container, typeof (T));
    }
