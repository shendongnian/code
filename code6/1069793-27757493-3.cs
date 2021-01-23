    [TestMethod]
    public void AttackingEnemyReducesHisLifes()
    {
        var game = new Game();
        int lifesBefore = game.EnemyLifes;
        game.AttackEnemy();
        Assert.AreEqual(lifesBefore - 1, game.EnemyLifes);
    }
