    [MulticastAttributeUsage(MulticastTargets.Assembly)]
    public class SampleAspectProvider : MulticastAttribute, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var myAspect = new MyAspect();
            var assembly = (Assembly) targetElement;
            foreach (var type in assembly.GetTypes())
            {
                if (/* type is a valid target */)
                {
                    foreach (var methodInfo in type.GetMethods())
                    {
                        yield return new AspectInstance(methodInfo, myAspect);
                    }
                }
            }
        }
    }
