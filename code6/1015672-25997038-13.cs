    public class Gem : ISpawnable
    {
        readonly string color;
        readonly int oneInThousandProbability;
        public Gem(string color, int oneInThousandProbability)
        {
            this.color = color;
            this.oneInThousandProbability = oneInThousandProbability;
        }
        public string Color { get { return this.color; } }
        public int OneInThousandProbability
        {
            get
            {
                return this.oneInThousandProbability;
            }
        }
        public object Clone()
        {
            return new Gem(this.color, this.oneInThousandProbability);
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
