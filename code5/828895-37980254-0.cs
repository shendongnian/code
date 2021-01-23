    public interface Animal
    {
        // Fields
        string voice { get; }
    }
    public static class AnimalHelper
    {
        // Called for any Animal
        public static string MakeSound(this Animal animal)
        {
            // Common code for all of them, value based on their voice
            return animal.voice;
        }
    }
    public class Dog : Animal
    {
        public string voice { get { return "Woof!"; } }
    }
    public class Purcupine : Animal
    {
        public string voice { get { return ""; } }
    }
