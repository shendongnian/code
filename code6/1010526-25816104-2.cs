    public class Hamster
    {
        public Task Creation { get; private set; }
        public Hamster()
        {
            Creation = CreateAsync();
        }
    }
    
    var hamster = new Hamster();
    await hamster.Creation;
