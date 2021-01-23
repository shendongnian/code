        public interface ICommand
        {
        }
        public interface ICommandHandler<T> where T : ICommand
        {
        }
