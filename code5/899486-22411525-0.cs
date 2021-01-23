      for(int a=1; a<=5; a++){
            for(int b=1; b<=20; b++){
                  for(int c=1; c<=20; c++){ //all 'for's must be in this order
                        input[a].Re = a * b; //for example
                        input[a].I = 0.0;
                        Alist[b,c] = input; //ERROR
