    public static class FoodFactory {
        public static void Create(IAnimal animal) {
            Dispatch (animal);
        }
        private static void Dispatch (dynamic animal) {
            InternalCreate (animal);
        }
        private static void InternalCreate (Dog dog) {
            Console.WriteLine("return dog food");
        }
        private static void InternalCreate (Fox fox) {
            Console.WriteLine("return fox food");
        }
    }
