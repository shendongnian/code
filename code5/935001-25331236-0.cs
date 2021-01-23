    [RoutePrefix("api/quotes")]
    public class QuotesController : ApiController
    {
        ...
        
        // POST api/Quote
        [ResponseType(typeof(Quote))]
        [Route]
        public IHttpActionResult PostQuote(Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Quotes.Add(quote);
            db.SaveChanges();
            return CreatedAtRoute("", new { id = quote.QuoteId }, quote);
        }
