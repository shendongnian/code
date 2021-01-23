    public class Faction 
    {
      // Other properties
      [PetaPoco.ResultColumn]
      public Entity Entity { get; set; }
    }
    public class Entity
    {
      // Other properties
      [PetaPoco.ResultColumn]
      public Character Character{ get; set; }
    }
    public class Character
    {
      // Properties of character object
    }
