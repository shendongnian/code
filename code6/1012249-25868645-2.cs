        public class ContainerForA
        {
            public IBaseA InstanceOfA { get; set; }
            public ContainerForA()
            {
                InstanceOfA = new ClassA();
            }
            private static ContainerForA EmptyContainerFactory()
            {
                return new ContainerForA()
                {
                    InstanceOfA = null
                };
            }
        }
        static void Main(string[] args)
        {
            var containerForA = new ContainerForA()
            {
                InstanceOfA = new ClassB { PropB = "I'm B" }
            };
            var model = RuntimeTypeModel.Create();
            var baseA = model.Add(typeof(IBaseA), true);
            baseA.AddSubType(101, typeof(IBaseB));
            baseA.AddSubType(102, typeof(ClassA));
            var baseB = model.Add(typeof(IBaseB), true);
            baseB.AddSubType(103, typeof(ClassB));
            var classA = model.Add(typeof(ClassA), true);
            classA.AddField(1, "PropA");
            var classB = model.Add(typeof(ClassB), true);
            classB.AddField(2, "PropB");
            var container = model.Add(typeof(ContainerForA), true);
            container.AddField(3, "InstanceOfA");
            container.SetFactory("EmptyContainerFactory");
            MemoryStream mem = new MemoryStream();
            model.Serialize(mem, containerForA);
            mem.Seek(0, SeekOrigin.Begin);
            var containerForADeserialized = model.Deserialize(mem, null, typeof(ContainerForA));
            Debug.WriteLine(containerForADeserialized);
        }
