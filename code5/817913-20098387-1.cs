    var service = A.Fake<IService>();
   
    testedObject.CallService("data");
    // verify your specific call to .PostData
    A.CallTo(() => service.PostData("data")).MustHaveHappened(Repeated.Exactly.Once);
    // verify that no more than 1 call was made to fake object
    A.CallTo(service).MustHaveHappened(Repeated.Exactly.Once); 
