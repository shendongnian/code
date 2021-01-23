    private object newFooLock = new object();
    public void NewFooMember(FooMember fooMember)
    {
      fooMember.NullGuard("fooMember");
      // This is the primary key
      lock (newFooLock) {        // now only one thread can get in here at a time
        fooMember.MemberKey = NextFooMemberKey();
        Repo.Add(fooMember);
        UnitOfWork.Commit();
      }
    }
