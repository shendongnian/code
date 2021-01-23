    public abstract class AbstractRequest
    {
        public abstract void Search();
    }
    public abstract class AbstractRequest<TResponseData> : AbstractRequest
                where TResponseData : IResponseData
    {
        public abstract GoodData BindData(TResponseData data);
    }
