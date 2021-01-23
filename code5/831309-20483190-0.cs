    var array = new string[,] { {"O", "O", null } };
    var _grid = new Mock<IGrid>();
    _grid.Setup(g => g.Squares).Returns(array);
    var game = new Game(_grid.Object);
    
    var oblivion = game.Play();
    
    Assert.IsNotNull(array[0, 3]);
