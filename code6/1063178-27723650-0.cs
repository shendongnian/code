    // Define other methods and classes here
    public abstract class EditSkillViewModel<T> where T : SkillBase
    {
        public T Skill { get; protected set; }
    	
    	protected EditSkillViewModel(T skill){
    		Skill = skill;
    	}
    }
    
    public static class EditSkillViewModelManager
    {
    	private static IDictionary<Type, Type> _types;
    	
    	public static EditSkillViewModel<T> CreateEditSkillViewModel<T>(T skill) 
    		where T : SkillBase
    	{
    		return (EditSkillViewModel<T>)Activator.CreateInstance(_types[typeof(T)], skill);
    	}
    	
    	static EditSkillViewModelManager()
    	{
    		var editSkillViewModelTypes = from x in Assembly.GetAssembly(typeof(SkillBase)).GetTypes()
    					let y = x.BaseType
    					where 	!x.IsAbstract && 
    							!x.IsInterface &&
    							y != null && 
    							y.IsGenericType &&
    							y.GetGenericTypeDefinition() == typeof(EditSkillViewModel<>)
    					select x;
    
    		_types = editSkillViewModelTypes
    			.Select(x => 
    				new { 
    						To = x, // EditWalkSkillViewModel
    						From = x.BaseType.GetGenericArguments()[0] // WalkSkill
    					})
    			.ToList()
    			.ToDictionary(x => x.From, x => x.To);
    			
    		_types.Dump();
    	}
    }
    
    public class EditWalkSkillViewModel : EditSkillViewModel<WalkSkill>
    {
        public EditWalkSkillViewModel(WalkSkill skill) : base(skill)
        {
        }
    }
    
    public class EditRunSkillViewModel : EditSkillViewModel<RunSkill>
    {
        public EditRunSkillViewModel(RunSkill skill): base(skill)
        {
        }
    }
