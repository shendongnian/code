    public class FeatureService {
    
      private readonly IMediator _mediator;
    
      public FeatureService(IMediator mediator) {
        _mediator = mediator;
      }
    
      public async Task ComplexBusinessLogic() {
        // retrieve relevant objects
        
        var results = await _mediator.Send(new GetRelevantDbObjectsQuery());
        // normally, this would have looked like...
        // var results = _myDbContext.DbObjects.Where(x => foo).ToList();
    
        // perform business logic
        // ...    
      }
    }
