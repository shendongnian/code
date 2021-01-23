    // With this approach the element can never be a pure abstract class (interface)!
	// The benefit of this version, in contrast to the previous one, is that the design
	// of the software can be easily adapted to the real worlds structure, since it is defined
	// dynamically, instead of staticaly like in the example above.
	abstract class Element
    {
        protected int id;   //GET - S[101], GS80 [102] etc PUT - AW[201], S[202], PD80[203] etc.. 
    	protected string name;
		// This instance itself maintains a list of self references
		protected List<Element> children;
    	
        protected Element(int id, string name)
        {
			this.children = new List<Element>();
            this.id = idx;   //GET - S[101], GS80 [102] etc PUT - AW[201], S[202], PD80[203] etc.. 
    		this.name = name;
    	}
    	
    	public void addChild(Element child){
    		this.children.add(child);
    	}
    	
    	public virtual void doSthOperation(){
    		Console.WriteLine("I am the element instance itself!");
    	}
    	// TODO -> Define further operations ...
    }
    
    // Maybe you won't need this. It just tells you that the current node doesn't have any children
    class Leaf : Element{
    	public void Leaf(int id, string name) : base(id, name){}
    	
    	public void addChild(Element child){
    		throw new SystemException("A leaf isn't allowed to have children!");
    	}
    	
    	public void doSthOperation(){
    		Console.WriteLine("I am the last node in the hierarchy!");
    	}
    }
    
    class Facility : Element
    {
        public void Facility(int id, string name) : base(id, name)
    	
    	public void doSthOperation(){
    		Console.WriteLine("I am a concreate instance of Faciltiy!");
    	}
    }
    
    class Factory : Element{
    	public void Factory(int id, string name) : base(id, name) { }
    	
    	public void doSthOperation(){
    		Console.WriteLine("I am a concreate instance of Factory!");
    	}
    }
	
	class SubSystem : Element{
    	public void SubSystem(int id, string name) : base(id, name) { }
    	
    	public void doSthOperation(){
    		Console.WriteLine("I am a concreate instance of SubSystem!");
    	}
    }
