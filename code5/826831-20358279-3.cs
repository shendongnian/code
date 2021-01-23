    public class GroupsViewModel : ViewModelBase
    {
    	public GroupsViewModel()
    	{
    		using (DBEntities db = new DBEntities())
    		{
    			GroupsAndCorrespondingEffects = (from g in db.Groups
    											 select new GroupAndCorrespondingEffect
    											 {
    												 GroupName = g.Name,
    												 CorrespondingEffect = g.Type_Effect.Name
    											 }
    											).ToList();
    
    			GroupsAndCorrespondingEffects.Add
    											(
    												new GroupAndCorrespondingEffect
    												{
    													GroupName = " Primary",
    													CorrespondingEffect = ""
    												}
    											);
    
    			GroupsAndCorrespondingEffects = GroupsAndCorrespondingEffects.OrderBy(g => g.GroupName).ToList();
    
    			Items = (from e in db.Type_Effect
    					 select e.Name).ToList();
    		}
    	}
    
    	public static GroupsViewModel CurrentInstance { get { return Instance; } }
    
    	private List<GroupAndCorrespondingEffect> _groupsAndCorrespondingEffects;
    	public List<GroupAndCorrespondingEffect> GroupsAndCorrespondingEffects
    	{
    		get
    		{
    			return _groupsAndCorrespondingEffects;
    		}
    		set
    		{
    			_groupsAndCorrespondingEffects = value;
    			OnPropertyChanged("GroupsAndCorrespondingEffects");
    		}
    	}
    
    	protected override void OnCaretIndexChanged()
    	{
    		for (int i = 0; i < GroupsAndCorrespondingEffects.Count; i++)
    		{
    			string wordToSearch = InputValue;
    
    			if (CaretIndex != 0 && CaretIndex > 0)
    			{
    				wordToSearch = InputValue.Substring(0, CaretIndex);
    			}
    
    			if (wordToSearch != null)
    			{
    				GroupsAndCorrespondingEffects[i].IsHighlighted = GroupsAndCorrespondingEffects[i].GroupName.StartsWith(wordToSearch);
    			}
    		}
    	}
    
    	protected override void OnInputValueChanged()
    	{
    		OnPropertyChanged("GroupsAndCorrespondingEffects");
    
    		for (int i = 0; i < GroupsAndCorrespondingEffects.Count; i++)
    		{
    
    			string wordToSearch = InputValue;
    
    			if (CaretIndex != 0 && CaretIndex > 0 && CaretIndex < InputValue.Length)
    			{
    				wordToSearch = InputValue.Substring(0, CaretIndex);
    			}
    
    			GroupsAndCorrespondingEffects[i].IsHighlighted = GroupsAndCorrespondingEffects[i].GroupName.StartsWith(wordToSearch);
    
    		}
    	}
    }
