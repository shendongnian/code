    var userid = user.Identifier;
    UserRepository.Stub(x => x
          .GetUser(Arg.Is(userid), Arg.Is(long.MinValue), out myVar)
          .OutRef(valueForMyVar)
          .Return(user);
