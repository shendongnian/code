    public class RN_BUDGET_SETTINGS : RN_AUDIT
    {
       public RN_BUDGET_SETTINGS()
       {
       }
       #region Properties
       [IsKey(true)]
       public dynamic ID { get; set; }
       public dynamic TANIM { get; set; }
       public dynamic DEGER { get; set; }
       #endregion
    }
