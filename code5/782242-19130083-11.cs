    class Game
    {
      public:
        static Game &shared_instance() {static Game game; return game;}
    
      private:
        // Make constructor private. Only shared_instance() method will create an instance.
        Game() {/*whatever initialisation you need*/}
    };
