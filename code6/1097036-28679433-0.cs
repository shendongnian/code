    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new Autofac.ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IActionHandler<>).Assembly)
                   .AsClosedTypesOf(typeof(IActionHandler<>));
            IContainer container = builder.Build();
            List<IAction> actions = new List<IAction>();
            actions.Add(new DisplayMessageAction("Test1"));
            actions.Add(new DisplayMessageAction("Test2"));
            actions.Add(new BeepMessageAction(200, 200));
            foreach (IAction action in actions)
            {
                Type actionHandlerType = typeof(IActionHandler<>).MakeGenericType(action.GetType()); 
                IActionHandler actionHandler = (IActionHandler)container.Resolve(actionHandlerType);
                actionHandler.Execute(action);
            }
        }
    }
    public interface IAction { }
    public interface IActionHandler
    {
        void Execute(IAction action);
    }
    public interface IActionHandler<T> : IActionHandler
        where T : IAction
    {
        void Execute(T IAction);
    }
    public abstract class ActionHandlerBase<T> : IActionHandler<T>
        where T : IAction
    {
        void IActionHandler.Execute(IAction action)
        {
            this.Execute((T)action);
        }
        public abstract void Execute(T IAction);
    }
    public class DisplayMessageAction : IAction
    {
        public DisplayMessageAction(String message)
        {
            this._message = message;
        }
        private readonly String _message;
        public String Message
        {
            get
            {
                return this._message;
            }
        }
    }
    public class DisplayMessageActionHandler : ActionHandlerBase<DisplayMessageAction>
    {
        public override void Execute(DisplayMessageAction action)
        {
            Console.WriteLine(action.Message);
        }
    }
    public class BeepMessageAction : IAction
    {
        public BeepMessageAction(Int32 frequency, Int32 duration)
        {
            this._frequency = frequency;
            this._duration = duration;
        }
        private readonly Int32 _frequency;
        private readonly Int32 _duration;
        public Int32 Frequency
        {
            get
            {
                return this._frequency;
            }
        }
        public Int32 Duration
        {
            get
            {
                return this._duration;
            }
        }
    }
    public class BeepMessageActionHandler : ActionHandlerBase<BeepMessageAction>
    {
        public override void Execute(BeepMessageAction action)
        {
            Console.Beep(action.Frequency, action.Duration);
        }
    }
