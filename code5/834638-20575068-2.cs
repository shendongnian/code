    public class process{
       public StringBuilder message = new StringBuilder();
    
       private void DoStep1
       {
          AddNote("start");
    
          var p2 = new process2();
          p2.DoStuff(message);
    
          var p3 = new process3();
          p3.DoStuff(message);
    
          SendEmailMethod(message);
       }
    
       private void AddNote(string msg)
       {
          //do stuff
          message.Append(msg);
       }
    }
    
    public class process2{
       public void DoStuff(StringBuilder stringBuilder)
       {
          //need to append msg to that variable - use stringBuilder
       }
    
    }
    
    public class process3{
    
       public void DoStuff(StringBuilder stringBuilder)
       {
          //need to append msg to that variable - use stringBuilder
       }
    
    }
