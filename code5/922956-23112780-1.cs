    public abstract class ChartHelper
    {
        protected  IEnumerable<IObject> _datalist;
        public ChartHelper()
        {
            _datalist = new List<IObject>();
        }
        public ChartHelper(IEnumerable<IObject> data)
        {
            _datalist = data;
        }
    }
