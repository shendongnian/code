    [Serializable]
    [AspectTypeDependency(AspectDependencyAction.Order,
                          AspectDependencyPosition.Before,
                          typeof(SynchronizedAttribute))]
    public class MeasureTimeAttribute : OnMethodBoundaryAspect
    {
        // ...
    }
