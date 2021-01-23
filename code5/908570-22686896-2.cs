    public class TransactionTaskDecorator<T> : ITask<T> {
        private readonly ITask<T> decoratee;
        public TransactionTaskDecorator(ITask<T> decoratee) {
            this.decoratee = decoratee;
        }
        public void Handle(T data) {
            using (var scope = new TransactionScope()) {
                this.decoratee.Handle(data);
                scope.Complete();
            }
        }
    }
