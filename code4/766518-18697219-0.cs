    public class ServiceSpecification
    {
        private const int BytesInWord = 8;
        public int? In { get; private set; }
        public int? Out { get; private set; }
        public static ServiceSpecification Parse(string s)
        {
            // parse intput string here
        }
        public bool IsSatisfiedBy(IService service)
        {
            if (In.HasValue && service.In != In.Value)
                return false;
            if (Out.HasValue && service.Out != Out.Value)
                return false;
            return true;
        }
    }
