    public void DoSomeWork()
    {
        using(IUnitOfWorkSession session = _unitOfWork.Begin())
        {    
            _userRepo.Add(session, someUser);
            _catRepo.Add(session, someCat);
            session.Commit();
        }
    }
