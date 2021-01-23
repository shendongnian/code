    class VariableLiker {
      private:
        bool isGood_;
      public:
        VariableLiker() : isGood_(false) {}
        void checkA(int a) {
          if (a > 5) {
            Print("Very well, a > 5");
            isGood_ = true;
          }
        }
        void checkB(int b){
        	if (isGood_ && b > 7)
        	  Print("Even better, b > 7");
        	else
        	  Print("I don't like your variables");
        }
    };
    //...
    VariableLiker variableLiker;
    variableLiker.checkA(a);
    variableLiker.checkB(b);
