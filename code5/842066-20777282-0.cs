    class NoIdeaWhatTheScenarioIs {
      private int y;
      private int x;
      void Add() { y += x; }
      void Sub() { y -= x; }
      Action GetAction(bool ifTrue) { if (ifTrue) { return Add; } else { return Sub; } }
      void DoStuff(IEnumerable<Thingie> things) {
        foreach(var thing in things) {
          GetAction(thing.condition)(); // <-- note the extra parens here
        }
      }
    }
