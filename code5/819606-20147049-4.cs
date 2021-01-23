    var character = new Character("Bob", 100, 70);
    character.HealthChanged += CharacterHealthChanged;
    var monster = new Character("Monster", 200, 10);
    monster.HealthChanged += CharacterHealthChanged;
    while (character.IsAlive && monster.IsAlive)
    {
        character.Attack(monster);
        monster.Attack(character);
    }
