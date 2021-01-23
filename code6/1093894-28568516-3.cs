    public class VMMain(){
         public void VMMain(){
            //don't forget null CTOR as MVC requires it...
         }
         public void VMMain(Guid userguid, string newusername){
            UserGuid = userguid;
            NewUserName = newusername;
            Part1 = new VM1(UserGuid, NewUserName);
            Part2 = new VM2();
            Part3 = new VM3();
         }
         public VM1 Part1 {get;set;}
         public VM2 Part2 {get;set;}
         public VM3 Part3 {get;set;}
         Guid UserGuid {get;set;}
         string NewUsername {get;set;}
    }
