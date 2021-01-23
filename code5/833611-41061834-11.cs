    public class MonkeyPatch : IAspect
    {
        static public void Patch(MethodInfo oldMethod, MethodInfo newMethod)
        {
            //update monkey patch dictionary
            MonkeyPatch.m_Dictionary[oldMethod] = newMethod;
            //release previous monkey patch for target method.
            Aspect.Release<MonkeyPatch>(oldMethod);
            //weave monkey patch for target method.
            Aspect.Weave<MonkeyPatch>(oldMethod);
        }
        static private Dictionary<MethodInfo, MethodInfo> m_Dictionary = new Dictionary<MethodInfo, MethodInfo>();
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            if (MonkeyPatch.m_Dictionary.ContainsKey(_Method))
            {
                yield return Advice(MonkeyPatch.m_Dictionary[_Method]);
            }
        }
    }
