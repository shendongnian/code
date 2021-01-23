    baseController.UnitOfWork.UserRepository.Expect(u => u.Get(Arg<Expression<Func<User, bool>>>.Is.Anything, Arg<Func<IQueryable<User>, IOrderedQueryable<User>>>.Is.Anything, Arg<string>.Is.Anything))
        .WhenCalled(invocation =>
            {
            var predicate = invocation.Arguments.First() as Expression<Func<User, bool>>;
            var query = predicate.Compile();
            invocation.ReturnValue = users.Where(query);
            });
