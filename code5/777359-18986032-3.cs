    List<CreatureCriteria> CreatureOptions{get;set;}
    EnumerateOptions()
    {
        foreach (Type t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICreature)))))
        {
            foreach (CreatureAttribute creatureAttribute in
                    t.GetCustomAttributes(typeof (CreatureAttribute), false)
                    .Cast<CreatureAttribute>()                    
                {
                    CreatureOptions.Add(
                        new CreatureCriteria{
                                Legs = creatureAttribute.NumberOfLegs,
                                HairColor = creatureAttribute.HairColor,
                                ...
                                ConcreteType = t
                         }
                    );
                }
        }
    }
