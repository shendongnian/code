    public abstract class CacheAction
    {
        //so it can't be inherited from other assemblies
        internal CacheAction() { }
    }
    public class ActionsTypeA : CacheAction
    {
        private ActionsTypeA() { }
        public static readonly ActionsTypeA SomthingFromACache = new ActionsTypeA();
        public static readonly ActionsTypeA SomethingElseFromACache = new ActionsTypeA();
    }
    public class ActionsTypeB : CacheAction
    {
        private ActionsTypeB() { }
        public static readonly ActionsTypeB SomthingFromBCache = new ActionsTypeB();
        public static readonly ActionsTypeB SomethingElseFromBCache = new ActionsTypeB();
    }
