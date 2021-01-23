    public class BaseService
    {
        protected IMapper _mapper;
     
        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
     
        public void AutoMapperDemo(){
            var questions = GetQuestions(token);
            return _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionModel>>(questions);
        }
     
        public IEnumerable<Question> GetQuestions(token){
            /*logic to get Questions*/
        }
    }
