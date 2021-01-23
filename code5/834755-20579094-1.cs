    //assuming in a service
    public void DoSomething() {
        using(var uow = new UnitOfWork()) {
            _repositoryA.UpdateSomething();
            _repositoryB.DeleteSomething();
            _uow.Commit();
        }
    }
