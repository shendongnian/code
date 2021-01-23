	public class TransactionLog 
	{
		Expression<Func<TransactionLog, bool>> IsDividend() {
			Expression<Func<TransactionLog, bool>> expression = tl => tl.SourceTypeID == (int)JobType.Dividend || tl.SourceTypeID == (int)JobType.DividendAcct;
			return expression;
		}
	}
	public class TransactionLogExtension
	{
		Expression<Func<TransactionLog, bool>> IsDividend(this TransactionLog log) {
			Expression<Func<TransactionLog, bool>> expression = tl => tl.SourceTypeID == (int)JobType.Dividend || tl.SourceTypeID == (int)JobType.DividendAcct;
			return expression;
		}
	}
