    static void Function(){
        //Do stuff
    }
    static void Main(){
      TaskFactory.StartNew(Function).wait();
    }
