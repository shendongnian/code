    [Serializable]
    public class CombinedAspect : MethodLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            yield return new AspectInstance(targetElement, new FirstAspect());
            yield return new AspectInstance(targetElement, new SecondAspect());
        }
    }
