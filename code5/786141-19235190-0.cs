    public interface INestedInterfaceTest<TChildType>
        where TChildType : INestedInterfaceTest<TChildType>
    {
        List<TChildType> children { get; set; }
    }
    public abstract class NestedInterfaceTest<TChildNestedInterface> : INestedInterfaceTest<TChildNestedInterface>
        where TChildNestedInterface : INestedInterfaceTest<TChildNestedInterface>
    {
        public List<TChildNestedInterface> children { get; set; }
        public virtual TNestedInterface GetNestedInterface<TNestedInterface>()
            where TNestedInterface : NestedInterfaceTest<TChildNestedInterface>, INestedInterfaceTest<TNestedInterface>, new()
        {
            return GateWay<TNestedInterface>.GetNestedInterface();
        }
    }
    public class GateWay<TNestedInterface>
        where TNestedInterface : class, INestedInterfaceTest<TNestedInterface>, new()
    {
        public static TNestedInterface GetNestedInterface()
        {
            List<TNestedInterface> nestedChildren = new List<TNestedInterface>();
            return new TNestedInterface
                {
                    children = nestedChildren
                };
        }
    }
    public class NestedClass : NestedInterfaceTest<NestedClass>
    {
        public NestedClass GetNestedInterface()
        {
            return GetNestedInterface<NestedClass>();
        }
    }
