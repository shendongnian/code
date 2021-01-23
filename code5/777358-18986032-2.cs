    public sealed class CreatureAttribute:Attribute
    {
        public int NumberOfLegs{get;set;}
        public Color HairColor{get;set;}
        public int NumberOfWings{get;set;}
        public bool BreathsFire{get;set;}
    }
    [CreatureAttribute(NumberOfLegs=6, HairColor = Color.Magenta, NumberOfWings=0, BreathsFire=True)]
    public class PurpleDragon: ICreature
    {
    ...
    }
