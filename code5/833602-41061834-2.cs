        static public void Patch(MethodInfo oldMethod, MethodInfo newMethod)
        {
            //instantiate aspect and apply it to the reflected type of old method.
            new MonkeyPatch(oldMethod, newMethod).Manage(oldMethod.ReflectedType);
        }
        private MethodInfo m_OldMethod;
        private MethodInfo m_NewMethod;
        private MonkeyPatch(MethodInfo oldMethod, MethodInfo newMethod)
        {
            this.m_OldMethod = oldMethod;
            this.m_NewMethod = newMethod;
        }
        override protected IEnumerable<Advice<T>> Advise<T>(MethodInfo method)
        {
            if (method == this.m_OldMethod)
            {
                //in AOP common usage, the substitute call the replaced method to decorate it.
                yield return Advice<T>.Create(this.m_NewMethod);
            }
        }
    }
