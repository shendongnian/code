    [ProtoContract(SkipConstructor=true)]
    public class ContainerForA
    {
        [ProtoMember(3)]
        public IBaseA InstanceOfA { get; set; }
        public ContainerForA()
        {
            InstanceOfA = new ClassA();
        }
    }
