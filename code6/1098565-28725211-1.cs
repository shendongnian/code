    [Test]
	public void VerifyPhoneNumber_Succeeded()
	{
		var test = TestFactory.ForConsumer<VerifyPhoneNumberConsumer>().New(x =>
		{
			x.ConstructUsing(() => _consumer);
			x.Send(_command, (scenario, context) => context.SendResponseTo(scenario.Bus));
		});
		var response = (IRestResponse<PhoneNumberVerificationResponse>)new RestResponse<PhoneNumberVerificationResponse>();
		response.Data = GetSuccessfulVericationResponse();
		var taskResponse = Task.FromResult(response);
		Expect.MethodCall(
			() => _client.ExecuteGetTaskAsync<PhoneNumberVerificationResponse>(Any<IRestRequest>.Value.AsInterface))
			  .Returns(taskResponse);
		test.Execute();
		Assert.IsTrue(test.Sent.Any<VerifyPhoneNumberSucceeded>());
	}
