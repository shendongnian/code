    public class Manager
    {
        public Card card1;
        public Card card2;
    }
    ...
    var manager = new Manager 
    {
        card1 = new CreatureCard();
        card2 = new SpellCard();
    }
    if (manager.card1 is CreatureCard)
    {
        var health = ((CreatureCard)manager.card1).Health;
        Console.WriteLine(health);
    }
    if (manager.card2 is SpellCard)
    {
        var effect = ((SpellCard)manager.card2).effect;
        Console.WriteLine(effect);
    }
