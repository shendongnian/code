    public class Player
    {
        .
        .
        public string Name {get;set;}
        public int Life {get;set;}
        .
        .
        public void eat(IEdible food)
        {
            Console.WriteLine(Name + " Ate the " + food.name);
            life += food.amountHealed;
        }
    }
