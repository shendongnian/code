    public class NPCTypeDataViewModel
    {
    	public string Name { 
    		get;
    		set;
    	}
    	
    	public List<NameAliasViewModel> Emotions {
    		get;
    		set;
    	}
    	
    	public NPCTypeDataViewModel(NPCTypeData data){
    		Name = data.Name;
    		Emotions = data.Emotions.Select(x => new NameAliasViewModel(x))
    								.ToList();
    	}
    	
    	public NPCTypeData GetModel(){
    		var ntd = new NPCTypeData(){
    			Name = Name,
    			Emotions = Emotions.Select(emo => emo.GetModel())
    								.ToList()
    		};
    		
    		return ntd;
    	}
    }
    
    public class NameAliasViewModel 
    {
    	public string Name {
    		get;
    		set;
    	}
    	
    	public string Alias {
    		get;
    		set;
    	}
    	
    	public NameAliasViewModel(NameAlias alias){
    		Name = alias.Name;
    		Alias = alias.Alias;
    	}
    	
    	public NameAlias GetModel(){
    		return new NameAlias(){
    			Name = Name,
    			Alias = Alias
    		};
    	}
    }
