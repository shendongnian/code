    public class MyHttpControllerDecorator<T> : MyHttpController
        where T : MyHttpController
    {
        public readonly T decoratee;
        public MyHttpControllerDecorator(T decoratee)
        {
            this.decoratee = decoratee;
        }
        public Task<HttpResponseMessage> ExecuteAsync(
            HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            return this.decoratee.ExecuteAsync(controllerContext, cancellationToken);
        }
        [ActionName("Default")]
        public DtoModel Get(int id)
        {
            return this.decoratee.Get(id);
        }
    }
