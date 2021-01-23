    public class Gem : ISpawnableObject
    {
        readonly string color;
        readonly int thousandInOneProbability;
        public Gem(string color, int thousandInOneProbability)
        {
            this.color = color;
            this.thousandInOneProbability = thousandInOneProbability;
        }
        public string Color { get { return this.color; } }
        public int ThousandInOneProbability
        {
            get
            {
                return this.thousandInOneProbability;
            }
        }
    }
    var RedGem = new Gem("Red", 250);
    var GreenGem = new Gem("Green", 400);
    var BlueGem = new Gem("Blue", 100);
    var PurpleGem = new Gem("Purple", 190);
    var OrangeGem = new Gem("Orange", 50);
    var YellowGem = new Gem("Yellow", 10);
    var spawnGenerator = new SpawnGenerator<Gem>(new[] { RedGem, GreenGem, BlueGem, PurpleGem, OrangeGem, YellowGem }, DateTime.Now.Millisecond);
    var randomGem = spawnGenerator.Spawn();
