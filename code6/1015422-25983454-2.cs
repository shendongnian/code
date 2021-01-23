    class BlogsController : Controller
    {
    
        public BlogsController(string data) : base(data)
        {
        }
    
        public override void getData()
        {
            Console.WriteLine(this.data);
        }
    
    }
