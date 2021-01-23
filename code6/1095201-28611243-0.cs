    [Test, AutoData]
    public void SutConstructorHasAppropriateGuardClauses(
        GuardClauseAssertion assertion)
    {
        assertion.Verify(
            typeof(ZipCode).GetConstructors(BindingFlags.Public));
    }
