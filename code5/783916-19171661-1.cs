    public class ItemDal : Common.Dal.BaseDal, ICommonEvents
    {
        private readonly CommonEvents _commonEvents;
        public ItemDal(CommonEvents commonEvents)
        {
            _commonEvents = commonEvents;
        }
        #region Implementation of ICommonEvents
        void ICommonEvents.BroadcastMessage(string text)
        {
            _commonEvents.BroadcastMessage(text);
        }
        #endregion
    }
