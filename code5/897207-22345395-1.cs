    private object newFooLock = new object();
    public void NewFooMember(FooMember fooMember)
    {
      fooMember.NullGuard("fooMember");
      lock (newFooLock) {        // now only one thread can get in here at a time
        try 
        {
          fooMember.MemberKey = NextFooMemberKey();
          Repo.Add(fooMember);
          UnitOfWork.Commit();
        }
        catch (Exception ex)
        {
          lastFooKey.Value--;    // decrement saved value
        }
      }
    }
    private object newFooKeyLock = new object();
    private static int? lastFooKey = null;
    public int NextFooMemberKey()
    { 
      // also lock the key generation, just to be safe
      lock (newFooKeyLock) { 
        if (lastFooKey == null) 
        {
          // only get from the db if the local value is not yet populated
          lastFooKey = Repo.Data.Max(fm => (int?)fm.MemberKey) ?? 1;
        }
        lastFooKey.Value++;
        return lastFooKey.Value;
      }
    }
