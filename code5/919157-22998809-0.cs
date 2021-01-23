    public void Execute(MyRequestParams p)
    {
      Parallel.ForEach(p.Quotes, q => {
        q.Premium = QuoteService.GetQuote(q);
        unitOfWork.GetRepository<Quote>().Add(q);
      });
    
      unitOfWork.Commit();
    }
