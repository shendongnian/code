    public static class MongoDbConventionRegistry
    {
        public static void Register()
        {
            var conventionPack = new ConventionPack {new StringObjectIdMemberMapConvention()};            
            ConventionRegistry.Register("CustomConventions", conventionPack, t => t.FullName.StartsWith("YourNamespace.Model.Entities.etc")); 
         }
    
     }
    public class StringObjectIdMemberMapConvention : IMemberMapConvention
    {
        private  readonly Regex _memberMatchRegex = new Regex(@"(^Id$)|(.+ObjectId?$)",RegexOptions.Compiled); // you can change this regex to match the convention you want
            
        public string Name {
                get { return "StringObjectId"; }
            }
    
            public void Apply(BsonMemberMap memberMap)
            {
                if (memberMap == null)
                    return;
                if(memberMap.MemberType == typeof(string) && _memberMatchRegex.IsMatch(memberMap.ElementName) )
                    memberMap.SetRepresentation(BsonType.ObjectId);
            }
    
        }
