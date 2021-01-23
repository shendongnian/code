    public class MyRepository
    {
        
        private static AnotherClass _anotherClass;
        private readonly IBaseRepository _baseRepository;
        private readonly IUid _uid;
        public MyRepository(IBaseRepository _baseRepository, IUid uid)
        {
            _baseRepository = baseRepository;
            _uid = uid;
            _anotherClass = BaseRepository.Db.SingleOrDefault<AnotherClass>();
           //another logic in here....
        }
        public string MethodUsingUid()
        {
            return _uid.SomeMethodHere(_anotherClass);
        }
    }
