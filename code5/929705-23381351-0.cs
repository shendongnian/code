    public class IslandProcessor : ModelProcessor
    {
        public override ModelContent Process(NodeContent input, ContentProcessorContext context)
        {
            ModelContent mc = base.Process(input, context);
            mc.Tag = CreateData(input);
            return mc;
        }
        ...
    }
