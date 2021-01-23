    public abstract class ChartHelper
    {
        protected  List<IObject> _datalist;
        public ChartHelper()
        {
            _datalist = new List<IObject>();
        }
        public ChartHelper(IEnumerable<IObject> data)
        {
            _datalist = new List<IObject>(data);
        }
    }
