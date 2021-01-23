    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Member member)
        {
            if (member.MemberInfo.GetCustomAttributes(typeof(IgnorePropertyAttribute), true).Length > 0)
            {
                return false;
            }
            return base.ShouldMap(member);
        }
    }
