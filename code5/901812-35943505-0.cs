    public class InputTypeA { public float Foo { get; set; } }
    public class OutputTypeA { public string Foo { get; set; } }
    public class InputTypeB { public float Bar { get; set; } }
    public class OutputTypeB { public string Bar { get; set; } }
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<float, string> mapFunc =
                src => String.Format(CultureInfo.InvariantCulture.NumberFormat, "{0:0.00}", src);
            var floatToStringConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InputTypeA, OutputTypeA>();
                cfg.CreateMap<float, string>().ConvertUsing(mapFunc);
            });
            var regularConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InputTypeB, OutputTypeB>();
            });
            IMapper floatToStringMapper = floatToStringConfig.CreateMapper();
            IMapper regularMapper = regularConfig.CreateMapper();
            var aIn = new InputTypeA() { Foo = 1f };
            var aOut = floatToStringMapper.Map<OutputTypeA>(aIn); 
            Console.WriteLine(aOut.Foo); // prints "1.00"
            var bIn = new InputTypeB() { Bar = 1f };
            var bOut = regularMapper.Map<OutputTypeB>(bIn);
            Console.WriteLine(bOut.Bar); // prints "1"
        }
    }
