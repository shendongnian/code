    [TestFixture]
    public class UnitTesty
    {
        ...
        [Test]
        public void GetServerStatus_Will_Call_Something_Of_SshMagic()
        {
            ...
            _mockSshMagic = Mock.Interface<ISshMagic>();
            MyClass myClass = new MyClass(_mockSshMagic);
            ...
            
            // we are setting up that _mockSshMagic.Something() will be called
            Expect.Once.MethodCall(() => _mockSshMagic.Something());
            ...
            // do your test here...
            myClass.("255.255.255.0", "Me", "MyPassword", ...);
            ...
            // we are checking that our expectations were met:
            AssertInvocationsWereMade.MatchingExpectationsFor(_mockSshMagic);
        }
    }
