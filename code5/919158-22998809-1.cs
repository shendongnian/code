    public void Execute(MyRequestParams p)
    {
      Parallel.ForEach(p.Quotes, q => {
        q.Premium = QuoteService.GetQuote(q);
      });
    
      unitOfWork.GetRepository<Quote>().AddAll(p.Quotes);
      unitOfWork.Commit();
    }
