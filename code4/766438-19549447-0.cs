    // C#:
    public List<string> testing()
    {
       return new List<string>()
       {
          {"Test"},
          {"Another test"}
       };
    }
    
    // Player object:
    public int Health { get { return 1; } }
    public int Hp() { return this.Health; }
    
    // lua:
    testing:Clear()
    print(ply.Health)
    print(ply:Hp())
    ply.Health = 2
    // You can not change a function style value like Hp(), So no way to change health this way except making a set function
