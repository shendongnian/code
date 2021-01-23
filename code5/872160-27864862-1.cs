    public class GetSomethingByIdQueryHandler : QueryHandler<GetSomethingByIdQuery, Something>
    {   
        public Something Handle(GetSomethingByIdQuery query)
        {
           using (var session = _store.OpenSession())
          {
            return session.Load<Something >(query.Id)   
          }
        }
    } 
