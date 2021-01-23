    void createGameInstance(type parameter)
    {
     if (!_inst)
       _inst = new Game(parameter);
    }
    
    Game *instance()
    {
     return _inst;
    }
