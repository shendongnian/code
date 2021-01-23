    var i = (int)Get(); //existing syntax
    var i = Get()(int); //what you propose
    var i = (int)Get<int>(typeof(int)); //existing syntax
    var i = Get<int>(typeof(int))(int); //what you propose
    var i = ((Mammoth)(Elephant)Get()).Trunk; //existing syntax
    var i = Get()(Elephant)(Mammoth).Trunk; //what you propose
    var i = ((Mammoth)((Elephant)Get()).Trunk).Trunk; //existing syntax
    var i = Get()(Elephant).Trunk(Mammoth).Trunk; //what you propose
