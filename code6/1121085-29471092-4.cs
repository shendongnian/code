      public IEnumerable<FilteredViewModel> GetFilteredQuotes()
      {
          Expression<Func<Quote, FilteredViewModel>> selector = q => new FilteredViewModel
          {
              Quote = q,
              QuoteProductImages = q.QuoteProducts.SelectMany(qp => qp.QuoteProductImages.Where(qpi => ExpressionHelper.FilterQuoteProductImagesByQuote().AsQuote()(q, qpi)))
          };
          selector = selector.ResolveQuotes();
          return _context.Context.Quotes.Select(selector);
      }
