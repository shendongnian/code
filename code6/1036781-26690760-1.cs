    public class AutoMapConfiguration : DefaultAutomappingConfiguration
    {
        private static readonly IList<string> IgnoredMembers = 
                            new List<string> { "Locations"}; // ... could be more...
        public override bool ShouldMap(Member member)
        {
            var shouldNotMap = IgnoredMembers.Contains(member.Name);
            return base.ShouldMap(member) && !shouldNotMap;
        }
    }
