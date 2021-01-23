    public class SomeAnimal : Animal
    {
    
    }
    
    public class AnimalMap : ClassMap<Animal>
    {
        public AnimalMap()
        {
          Schema("dbo");
          Table("Animals");   
    
          Id(x => x.Id).Column("ID").GeneratedBy.Identity();
          Map(x => x.FoodClassification).Column("FoodClassification");
          Map(x => x.BirthDate).Column("BirthDate");
          Map(x => x.Family).Column("Family");
    
          DiscriminateSubClassesOnColumn().Formula("IIF(classtype = 'dog', 'dog', 'someAnimal')");
        }
    }
    
    public class SomeAnimalMap : SubclassMap<SomeAnimal>
    {
        public SomeAnimalMap()
        {
              ReadOnly();
    
              DiscriminatorValue("someAnimal");
              Map(x => x.ClassType).Column("classtype");
        }
    }
