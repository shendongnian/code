     internal class Program
        {
            // interface
            public interface IHasLegs
            {}
    
            // base class
            public class Animal
            {}
    
            public class AnimalWithLegs : Animal, IHasLegs
            {}
    
            // Animals
            public class Donkey : AnimalWithLegs
            {}
    
            public class Lizard : AnimalWithLegs
            {}
    
            public class Snake : Animal
            {}
    
            // example of inanimte objects. (lifeless)
            public class Table : IHasLegs
            {}
    
            public class Desk : Table
            {}
    
            public class ConferenceTable : Table
            {}
    
            //public class Wife : BrainLessObject{} //hmm.. wrong place.. its still animated object..
    
            //example for cages
            public class ListOfIhasLegs : List<IHasLegs>
            {}
    
            public class ListOfAnimals : List<Animal>
            {}
    
            public class ListOfAnimalsWithLegs : List<AnimalWithLegs> 
            {}
    
    
            // usage examples.
            private static void Main(string[] args)
            {
                var donkeyInstance = new Donkey();
                var lizardInstance = new Lizard();
                var snakeInstance = new Snake();
    
                var tableInstance = new Table();
                var deskInstance = new Desk();
                var conferenceTalbeInstance = new ConferenceTable();
    
                var listOfThingsWithLegs = new ListOfIhasLegs
                {
                    donkeyInstance,
                    lizardInstance,
                    tableInstance,
                    deskInstance,
                    conferenceTalbeInstance
                };
    
                var listOfAnimals = new ListOfAnimals
                {
                    donkeyInstance,
                    lizardInstance,
                    snakeInstance
                };
    
                var cageOfAnimalsWithLegs = new ListOfAnimalsWithLegs
                {
                    donkeyInstance,
                    lizardInstance,
                };
            }
    
        }
