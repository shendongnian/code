     public class SampleRegistery : Registry
            {
                public SampleRegistery ()
                {
                    ForRequestedType<IService>().TheDefaultIsConcreteType<MyService>();
                }
            }
