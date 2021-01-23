    public class Hamster
    {
        public Task Creation;
        public Hamster()
        {
            Creation = CreateAsync();
        }
    }
    
    var hamster = new Hamster();
    await hamster.Creation;
