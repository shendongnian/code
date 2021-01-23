    public class OrganizationInterceptor : IInterceptionBehavior
    {
        private int OrgId { get; set; }
        private List<int> orgsWithBiggerQuota;
        public OrganizationInterceptor(int orgId)
        {
            OrgId = orgId;
            WillExecute = orgId > 0;
        }
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var ret = getNext()(input, getNext);
            if (input.MethodBase.IsSpecialName && input.MethodBase.Name == "get_Quota" &&
                this.orgsWithBiggerQuota.Contains(OrgId))
                ret.ReturnValue = (int)ret.ReturnValue + 100;
            return ret;
        }
        public bool WillExecute { get; set; }
    }
