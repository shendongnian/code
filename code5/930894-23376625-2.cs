    public class TheController : Controller
    {
        private readonly IRepository<MyComplexClass1> complexClassRepository;
        private readonly IRepository<ComplexResult> complexResultRepository;
    
        // this can use IoC if needed, no probs
        public TheController(IRepository<MyComplexClass1> complexClassRepository, IRepository<ComplexResult> complexResultRepository)
        {
            this.complexClassRepository = complexClassRepository;
            this.complexResultRepository = complexResultRepository;
        }
    
        // I know about HTTP
        public void Post(int id, int value)
        {
            var entity = this.complexClassRepository.Find(id);
            
            var complex3 = new MyComplexClass3(value);
            var result = entity.CrazyComplexCalculation(complex3);
    
            this.complexResultRepository.Save(result);  
        }
    }
