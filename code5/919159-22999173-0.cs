    public async Task Execute(MyRequestParams p)
    {
      foreach (var quote in p.Quotes)
      {
         //Of course, you'll need an async endpoint.
         var q.Premium = await QuoteService.GetQuoteAsync(q);
      }
    
      unitOfWork.GetRepository<Quote>().AddAll(p.Quotes);
      await unitOfWork.SaveChangesAsync();
    }
