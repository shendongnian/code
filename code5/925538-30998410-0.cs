    public ActionResult(A a)
    {
      A aa = repo.Find(...);
      // some logic
      repo.Detach(aa);
      repo.Update(a);
    }
