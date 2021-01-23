    public interface IAnimal { }
    public interface INoisyAnimal : IAnimal {
        string MakeSound();
    }
    public static class AnimalExtensions { 
        public static string MakeSound(this IAnimal someAnimal) {
            if (someAnimal is INoisyAnimal) {
                return (someAnimal as INoisyAnimal).MakeSound();
            }
            else {
                return "Unknown Noise";
            }
        }
    }
    public class Dog : INoisyAnimal {
        public string MakeSound() {
            return "Bark";
        }
    }
	
    public class Porcupine : IAnimal { }
