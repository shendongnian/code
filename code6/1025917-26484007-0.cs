    public class SkillsDomainService:ISkillsDomainService
    {
      public void AddSkill(string name){}
      public void DeleteSkillById(int id){}
      ..... etc
    }
    public class Repository:IRepository
    {
       public T Get(int id){}
      public IEnumerable<T>GetAll(){}
    }
