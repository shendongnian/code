    public void Initialize() 
    {
        List<Monsters> startersPokemon = new List<Monsters>();  
        startersPokemon.Add(
        new Monsters
        (
            Enums.Species.PIKACHU, 
            Enums.Rarity.rare, 
            Enums.Region.Pallet, 
            Enums.Type.electric
        )
        );
    }
