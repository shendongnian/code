    public class Fx
    {
        public int TradeId { get; set; }
        public string TradeRef { get; set; }
        public decimal PaymentAmount { get; set; }
        ...
    }
    (CashFlow, Trade) => new Fx
    {
        TradeId = CashFlow.TradeId,
        TradeRef = Trade.TradeReference,
        PaymentAmount = CashFlow.PaymentAmount,
        ...
    }
