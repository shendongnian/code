    public class Observation : IAspect
    {
        static public void Observe(MethodInfo method, Action action)
        {
            //update observation dictionary
            Observation.m_Dictionary[method] = action;
            //release observation aspect for target method
            Aspect.Release<Observation>(method);
            //weave observation aspect for target method.
            Aspect.Weave<Observation>(method);
        }
        static private Dictionary<MethodInfo, Action> m_Dictionary = new Dictionary<MethodInfo, Action>;
        public IEnumerable<IAdvice> Advice(MethodInfo method)
        {
            if (Observation.m_Dictionary.ContainsKey(method))
            {
                yield return Advice.Basic.After(Observation.m_Dictionary[method]);
            }
        }
    }
