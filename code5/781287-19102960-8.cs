        public class AnimalMediator
        {
            public void MakeNoise( Animal animal )
            {
                if ( typeof( animal ) is Dog ) (animal as Dog).Bark();
                else if ( typeof( animal ) is Cat ) (animal as Cat).Meow();
            }
        }
