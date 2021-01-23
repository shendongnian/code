    _agreementRepositoryMock.Setup(m => m.SingleOrDefaultIncluding
      (
        It.IsAny<Expression<Func<Agreement, bool>>>(),
        It.IsAny<Expression<Func<Agreement, object>>[]>()
      )
      ).Returns(AgreementMocks.GetOne());
