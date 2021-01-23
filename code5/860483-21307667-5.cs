    // This doesn't work. The repositories will merge.
    var repository1 = new InMemoryAuthRepository();
	repository1.CreateUserAuth(new UserAuth { Id = 1, UserName = "cburns", FullName = "Charles Montgomery Burns" }, "excellent");
	repository1.CreateUserAuth(new UserAuth { Id = 2, UserName = "bartsimpson", FullName = "Bart Simpson" }, "Ay caramba");
	repository1.CreateUserAuth(new UserAuth { Id = 3, UserName = "homersimpson", FullName = "Homer J. Simpson" }, "donuts");
	var repository2 = new InMemoryAuthRepository();
	repository2.CreateUserAuth(new UserAuth { Id = 1, UserName = "thehulk", FullName = "The Hulk" }, "pebbles");
	repository2.CreateUserAuth(new UserAuth { Id = 2, UserName = "captainamerican", FullName = "Captain America" }, "redwhiteblue");
	repository2.CreateUserAuth(new UserAuth { Id = 3, UserName = "spiderman", FullName = "Spider Man" }, "withgreatpower");
