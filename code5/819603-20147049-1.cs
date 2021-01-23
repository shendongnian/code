    var character = new Character("Bob", 100, 70);
    var monster = new Character("Monster", 200, 10);
    // Fight!
    while(character.IsAlive && monster.IsAlive)
        character.Attack(monster);
