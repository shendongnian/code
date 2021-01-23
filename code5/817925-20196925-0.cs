    [TestClass]
    public class AutoMapperTests
    {
        private readonly IEnumerable<Dto> _testDtos;
        private readonly IEnumerable<Entity> _testEntities;
        public AutoMapperTests()
        {
            _testDtos = new List<Dto>
            {
                new Dto()
                {
                    Id = 0,
                    Fk_Id = 8,
                    Price = 350000
                }
            };
            _testEntities = new List<Entity>
            {
                new Entity()
                {
                    Id = 8,
                    Price = 68000
                }
                ,
                new Entity()
                {
                    Id = 6,
                    Price = 350000
                }
            };
        }
        [TestInitialize]
        public void TestInitialize()
        {
            Mapper.Reset();
        }
        [TestMethod]
        public void AutoMapperIgnore_TwoCollectionsWithOneCommonElementMappedFromDtoToEntityIgnoreId_SameWithUnchangedIdAndNewPrice()
        {
            //Assign
            Mapper.CreateMap<Dto, Entity>()
                .ForMember(destination => destination.Id, opt => opt.Ignore());
            AutoMapperIgnore_TwoCollectionsWithOneCommonElementMappedFromDtoToEntity_SameWithUnchangedIdAndNewPrice(true);
        }
        [TestMethod]
        public void AutoMapperIgnore_TwoCollectionsWithOneCommonElementMappedFromDtoToEntityUseDestinationtValueForId_SameWithUnchangedIdAndNewPrice()
        {
            //Assign
            Mapper.CreateMap<Dto, Entity>()
                .ForMember(destination => destination.Id, opt => opt.UseDestinationValue());
            AutoMapperIgnore_TwoCollectionsWithOneCommonElementMappedFromDtoToEntity_SameWithUnchangedIdAndNewPrice(true);
        }
        private void AutoMapperIgnore_TwoCollectionsWithOneCommonElementMappedFromDtoToEntity_SameWithUnchangedIdAndNewPrice(bool isExceptedSame)
        {
            //Assign
            var exceptedPrice = _testDtos.First().Price;
            //Act
            Entity entityBeforeMapping = _testEntities.First(testEntity => testEntity.Id == _testEntities.First().Id);
            IEnumerable<Entity> foundEntities = _testEntities.Join(_testDtos, e => e.Id, e => e.Fk_Id, (entity, dto) => Mapper.Map(dto,entity));
            Entity entityAfterMapping = foundEntities.First();
            //Assert
            if (isExceptedSame)
            {
                Assert.AreSame(entityBeforeMapping, entityAfterMapping);
            }
            Assert.AreEqual(entityBeforeMapping.Id, entityAfterMapping.Id);
            Assert.AreEqual(exceptedPrice, entityAfterMapping.Price);
        }
        [TestMethod]
        public void AutoMapperIgnore_TwoObjectMappedWithIgnoreId_SameWithUnchangedIdAndNewPrice()
        {
            //Assign
            Mapper.CreateMap<Dto, Entity>()
                .ForMember(destination => destination.Id, opt => opt.Ignore());
            var testDto = new Dto()
            {
                Id = 0,
                Fk_Id = 8,
                Price = 350000
            };
            var testEntity = new Entity()
            {
                Id = 8,
                Price = 68000
            };
            var exceptedPrice = testDto.Price;
            //Act
            Entity entityBeforeMapping = testEntity;
            Mapper.Map(testDto, testEntity);
            Entity entityAfterMapping = testEntity;
            //Assert
            Assert.AreSame(entityBeforeMapping, entityAfterMapping);
            Assert.AreEqual(entityBeforeMapping.Id, entityAfterMapping.Id);
            Assert.AreEqual(exceptedPrice, entityAfterMapping.Price);
        }
        internal class Dto
        {
            public int Id { get; set; }
            public int Fk_Id { get; set; }
            public Single? Price { get; set; }
        }
        internal class Entity
        {
            public int Id { get; set; }
            public Single? Price { get; set; }
        }
    }
