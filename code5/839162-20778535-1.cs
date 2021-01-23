    public class TheServices : Service
    {
        public IBaseRepository BaseRepository { get; set; } //Injected By IoC
        public IUid Uid { get; set; } // Injected By IoC
        public object Post(some_Dto dto)
        {
            var Repo= new MyRepository(BaseRepository, Uid);
            return Repo.MethodUsingUid();
        }
    }
