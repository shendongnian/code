    class Game
    {
     static Game *_inst;
     public:
      static Game *instance() {if (!_inst) _inst = new Game(); return _inst;}
    };
