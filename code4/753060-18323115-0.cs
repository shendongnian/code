    class User
    {
        //..
    }
    interface IUserRepository
    {
        public function findAllUsers();
    }
    class UserRepository extends DoctrineRepository implements IUserRepository
    {
        public function getAllUsers()
        {
            return $this->findAll();
        }
    }
    class AdminController extends Controller
    {
        private $repository;
        public function __Construct(IUserRepository $repository )
        {
            $this->repository = $repository;
        }
        public function ActionResult_ListUsers()
        {
            $users = $this->repository->getAllUsers();
            // Do some clever View method thing with $users as the model
        }
