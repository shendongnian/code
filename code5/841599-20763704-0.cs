    internal class AnimalProxy : IAnimal
    {
        private object _target;
        public AnimalProxy(object target)
        {
            _target = target;
        }
        public string GetName()
        {
            //probably want to add error handling
            return object.GetType().GetMethod("GetName").Invoke(_target) as string;
        }
    }
