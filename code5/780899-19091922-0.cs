    private MemberController controller;
    private Mock<IMemberRepository> repositoryMock;
    private Member member;
    [SetUp]
    public void Setup()
    {
        repositoryMock = new Mock<IMemberRepository>();
        controller = new MemberController(repositoryMock.Object);
        member = new Member { MemID = 123, MemName = "sruthy" };
    }
    [Test]
    public void ShouldCreateMemberWhenItIsValid()
    {
        var result = (RedirectToRouteResult)controller.Create(member);
        Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        repositoryMock.Verify(r => r.Add(member));
    }
    [Test]
    public void ShouldNotCreateMemberWhenItIsNotValid()
    {
        controller.ModelState.AddModelError("MemName", "Something wrong");
        var result = (ViewResult)controller.Create(member);
        Assert.That(result.ViewName, Is.Empty);
    }
