    public class ConfigurableServicePersistenceMapper
    {
        public ConfigurableServiceId Id { get; set; }
        public string Description { get; set; }
        public HashSet<Group> Groups { get; set; }
        public Dependencies Dependencies { get; set; }
    }
    public class ConfigurableServiceSerializer : BsonBaseSerializer
    {
        public override void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
        {
            // implement using bsonWriter
            if (nominalType != typeof(ConfigurableService))
                throw new Exception("Object should be of type 'ConfigurableService'");
            var obj = (ConfigurableService)value;
            var map = new ConfigurableServicePersistenceMapper()
            {
                Dependencies = obj.Dependencies,
                Description = obj.Description,
                Groups = obj.Groups,
                Id = obj.Id
            };
            BsonSerializer.Serialize(bsonWriter, map);
        }
        public override object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
        {
            // implement using bsonreader
            if (nominalType != typeof(ConfigurableService))
                throw new Exception("object should be of type 'ConfigurableService'");
            var bson = BsonSerializer.Deserialize<BsonDocument>(bsonReader);
            var configurableServiceMapper = BsonSerializer.Deserialize<ConfigurableServicePersistenceMapper>(bson);
            var configurableService = new ConfigurableService(configurableServiceMapper.Id)
            {
                Description = configurableServiceMapper.Description
            };
            foreach (var group in configurableServiceMapper.Groups)
            {
                configurableService.NewGroup(group.Id);
                var retrievedGroup = configurableService.GetGroup(group.Id);
                retrievedGroup.Description = group.Description;
                foreach (var sku in group.Skus)
                {
                    retrievedGroup.Add(sku);
                }
                // set requirements
                List<Group> groupList = new List<Group>(configurableServiceMapper.Groups);
                foreach (var sku in group.Skus)
                {
                    List<string> dependencies =
                        new List<string>(configurableServiceMapper.Dependencies.GetDependenciesFor(sku));
                    foreach (var dependencySkuString in dependencies)
                    {
                        retrievedGroup.SetRequirementFor(sku)
                            .Requires(new SkuId(dependencySkuString));
                    }
                }
            }
            return configurableService;
        }
    }
