    // This is a variant type. At each single time it can hold one case (a value)
    // from a predefined set of cases. All classes that implement this interface
    // consitute the set of the valid cases of the variant. So in order to
    // add a new case to the variant there must be another class that implements
    // this interface.
    public interface ISomeAnimal
    {
        // This method introduces any possible case the variant can hold to a processing
        // function that turns the value of that case into some result.
        // Using delegates instead of an interface saves us a lot of typing!
        TResult GetProcessed<TResult>(
            Func<Cat, TResult> processCat,
            Func<Fish, TResult> processFish
        );
    }
    // A case that represents a cat from the ISomeAnimal variant.
    public class Cat : ISomeAnimal
    {
        public CatsHead Head { get; set; }
        public CatsBody Body { get; set; }
        public CatsTail Tail { get; set; }
        public IEnumerable<CatsLeg> Legs { get; set; }
        public TResult GetProcessed<TResult>(
            Func<Cat, TResult> processCat,
            Func<Fish, TResult> processFish
        ) {
            // for this particular case (being a cat) we pick the processCat delegate
            return processCat(this);
        }
    }
    // A case that represents a fish from the ISomeAnimal variant.
    public class Fish : ISomeAnimal
    {
        public FishHead Head { get; set; }
        public FishBody Body { get; set; }
        public FishTail Tail { get; set; }
        public TResult GetProcessed<TResult>(
            Func<Cat, TResult> processCat,
            Func<Fish, TResult> processFish
        ) {
            // for this particular case (being a fish) we pick the processFish method
            return processFish(this);
        }
    }
    public static class AnimalPainter
    {
        // Now, in order to process a variant, in this case we stil want to
        // add an animal to a picture, we don't need a visitor anymore.
        // All the painting logic stays within the same method.
        // Which is:
        // 1. Much less typing.
        // 2. More readable.
        // 3. Easier to maintain.
        public static void AddAnimalToPicture(Picture picture, ISomeAnimal animal)
        {
            animal.GetProcessed<Nothing>(
                cat =>
                {
                    picture.AddBackground(new SomeHouse());
                    picture.Add(cat.Body);
                    picture.Add(cat.Head);
                    picture.Add(cat.Tail);
                    picture.AddAll(cat.Legs);
                    return Nothing.AtAll;
                },
                fish =>
                {
                    picture.AddBackground(new SomeUnderwater());
                    picture.Add(fish.Body);
                    picture.Add(fish.Tail);
                    picture.Add(fish.Head);
                    return Nothing.AtAll;
                }
            );
        }
