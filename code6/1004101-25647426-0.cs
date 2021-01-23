    public interface IControllerProxy
    {
        public bool IsConnected { get; }
        public void Connect();
    }
    public interface ITagProxy
    {
        public IControllerProxy Controller { get; }
        public int Length { get; set; }
        public int ErrorCode { get; }
    }
    public interface IProxyFactory
    {
        IControllerProxy CreateControllerProxy(string ip, string slot, int timeout);
        ITagProxy CreateTagProxy(IControllerProxy clx, string tagName, WrappedClasses.ATOMIC dataType);
        ITagProxy CreateTagWrapper(IControllerProxy clx, WrappedClasses.ATOMIC dataType, int length);
    }
    private class ConcreteControllerProxy : IControllerProxy
    {
        private WrappedClasses.Controller _clx;
        public ConcreteControllerProxy(string ip, string slot, int timeout)
        {
            _clx = new WrappedClasses.Controller(ip, slot, timeout);
        }
        public bool IsConnected
        {
            get { return _clx.IsConnected; }
        }
        public void Connect()
        {
            _clx.Connect();
        }
        public WrappedClasses.Controller Controller { get { return _clx; } }
    }
    private class ConcreteTagProxy : ITagProxy
    {
        private WrappedClasses.Tag _tag;
        public ConcreteTagProxy(WrappedClasses.Tag tag)
        {
            _tag = tag;
        }
        public ConcreteTagProxy(WrappedClasses.Controller clx, string tagName, WrappedClasses.ATOMIC dataType)
        {
            _tag = new WrappedClasses.Tag(clx, tagName, dataType);
        }
    }
    public class ConcreteProxyFactory : IProxyFactory
    {
        public IControllerProxy CreateControllerProxy(string ip, string slot, int timeout)
        {
            return new ConcreteControllerProxy(ip, slot, timeout);
        }
        public ITagProxy CreateTagProxy(IControllerProxy clx, string tagName, WrappedClasses.ATOMIC dataType)
        {
            ConcreteControllerProxy controllerWrapper = clx as ConcreteControllerProxy;
            return new ConcreteTagProxy(controllerWrapper.Controller, tagName, dataType);
        }
        public ITagProxy CreateTagWrapper(IControllerProxy clx, WrappedClasses.ATOMIC dataType, int length)
        {
            ConcreteControllerProxy controllerWrapper = clx as ConcreteControllerProxy;
            WrappedClasses.Tag tag = new WrappedClasses.Tag
            {
                Controller = controllerWrapper.Controller,
                DataType = dataType,
                Length = length
            };
            return new ConcreteTagProxy(tag);
        }
    }
    public class Processor
    {
        protected IProxyFactory _factory;
        private IProxyFactory Factory
        {
            get
            {
                if (_factory == null )
                {
                    _factory = new ConcreteProxyFactory();
                }
                return _factory;
            }
        }
        private IControllerProxy _clx;
        private ITagProxy _tag;
        public bool Connect(string ip, string slot, int timeout, bool blockWrites, string tagName)
        {
            _clx = Factory.CreateControllerProxy(ip, slot, timeout);
            if (_clx != null)
            {
                _clx.Connect();
                if (_clx.IsConnected)
                {
                    if (tagName != null)
                    {
                        _tag = Factory.CreateTagProxy(_clx, tagName, WrappedClasses.ATOMIC.DINT);
                        return ((_tag.ErrorCode == 0) && _tag.Controller.IsConnected);
                    }
                    _tag = Factory.CreateTagWrapper(_clx, WrappedClasses.ATOMIC.DINT, 1);
                    return (_tag.Controller.IsConnected);
                }
            }
            return false;
        }
    }
    // This class would be in your test suite
    public class TestableProcessor : Processor
    {
        public IProxyFactory Factory
        {
            get { return this._factory; }
            set { this._factory = value; }
        }
    }
