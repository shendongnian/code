     public class MyModel{
       public string OptionA {get;set;}
       public string OptionB {get;set;}
       public void Post(){
              var userTextA = OptionA;
              var UserTextB = OptionB;
       }
    }
    public ActionResult MyController(){
        var vm = new MyModel();
        return view(vm);
    }
    [HttpPost]
     public ActionResult MyController(MyModel vm){
       if(modelstate.isValid){
              
             vm.post();
       }
    }
