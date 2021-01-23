    var game = new GameManager
        {
            player = new Player { gameObject = new GameObject { Name = "Stu" } }
        };
    var interpreter = new Interpreter();
    var parameters = new[] {
                new Parameter("game", game)
                };
    var result = interpreter.Eval("game.player.gameObject.Name", parameters);
