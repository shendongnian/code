    //In Order class
    public abstract void DoIt(){}
    
    //In OrderSubClass class
    public override void DoIt(){
      //Do Something
    }
    
    //Client code
    private void doSomething( Order theOrder){
      theOrder.DoIt();
    }
