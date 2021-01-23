    public interface IThisMetaDataProvider
    {
        Metadata ThisMetadata {get;}
    }
    [Serializable]
    [MulticastAttributeUsage(PersistMetaData = true)]
    [IntroduceInterface(typeof(IThisMetadataProvider))]
    public class MetaDataAspect : LocationInterceptionAspect, IInstanceScopedAspect
    {
        public Metadata ThisMetadata {get; private set;}
        public void RuntimeInitializeInstance() { ThisMetadata = new Metadata(); }
        ...
    }
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    public class CallInterceptionAspect : MethodLevelAspect, IMethodInterceptionAspect
    {
        public void OnInvoke(MethodInterceptionArgs args)
        {
            ((IThisMetadataProvider)args.Instance).ThisMetaData.Id = args.Arguments[0];
        }
    }
