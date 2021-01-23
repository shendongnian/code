    [Test]
    public void ctor_whenviewbuttonclick_callsviewButtonClickevent()
    {
        var view = Substitute.For<IView>();
        var repo = Substitute.For<Repository>();
        //Stub out GivenId
        view.GivenId.Returns("42");
        Student st = new Student();
        //Make GetById return a specific Student for the expected ID
        repo.GetById(42).Returns(x => st);
        StudentPresenter sp = new StudentPresenter(view, repo);
        view.ButonClick += Raise.Event<Action>();
        view.Received().GetStudent(st);
    }
