    internal static ITfsVcPromotionManager CreateUnityObjects()
    {
        var unityContainer = new UnityContainer();
        unityContainer.RegisterType<ITfsVcPromotionManager, TfsVcPromotionManager>();
        unityContainer.RegisterType<ITfsVcQaCheckinWorker, TfsVcQaCheckinWorker>();
        unityContainer.RegisterType<ITfsVcQaCheckoutWorker, TfsVcQaCheckoutWorker>();
        return unityContainer.Resolve<ITfsVcPromotionManager>();
    }
