    class Game
    {
     public:
      static Game *instance() {if (!_inst) _inst = new Game(); return _inst;}
     private:
      static Game *_inst;
      // Make ctor private You won't be able to create an instance without instance() method 
      Game() {/*whatever initialisation you need*/}
    };
