    public class TransactionObjectContent : ObjectContent
    {
         private ISession _session;
         public TransactionObjectContent(Type type, object value, MediaTypeFormatter formatter, ISession session, HttpContentHeaders headers)
             : base(type, value, formatter)
         {
             _session = session;
             foreach (var header in headers)
             {
                  response.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
             }
         }
         protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context)
         {
             await base.SerializeToStreamAsync(stream, context); // let it write the response to the client
             // here's the meat and potatoes. you'd add anything here that you need done after the response is written.
             if (_session.Transaction.IsActive) _session.Transaction.Commit();
         }
         protected override void Dispose(bool disposing)
         {
             base.Dispose(disposing);
             if (disposing)
             {
                 if (_session != null)
                 {
                     // if transaction is still active by now, we need to roll it back because it means an error occurred while serializing to stream above.
                     if (_session.Transaction.IsActive) _session.Transaction.Rollback();
                     _session = null;
                 }
             }
         }
    }
