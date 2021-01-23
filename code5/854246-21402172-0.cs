    using Enumerations;
    namespace Interfaces
    {
        interface ILevel : MarshalByRefObject
        {
            int changeDirection(MoveDirection newDirection);
        }
    }
    namespace Enumerations
    {
        public enum MoveDirection { Right, Left, Down, Up };
    }
