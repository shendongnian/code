    _agreementRepositoryMock.Setup(m => m.SingleOrDefaultIncluding
      (
        It.IsAny<Expression<Func<Agreement, bool>>>(),
        It.Is<Expression<Func<Agreement, object>>[]>(array => array.Length == 2)
      )
      ).Returns(AgreementMocks.GetOne());
