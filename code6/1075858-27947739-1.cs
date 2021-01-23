    public class SkillTypeRepository :  GenericRepository<SkillType>, ISkillTypeRepository 
    {            
        public SkillTypeRepository() : base(new SkillManagementEntities())
        {
            
        }
     //rest of code etc
    }
