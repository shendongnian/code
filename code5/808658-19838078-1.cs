    public class Runner {
      public virtual void UponFinish(){
         //...
      }
    }
    public class Expert : Runner {
      public override void UponFinish(){
        //You talked about the time, I asked for clarification on this
        //but it's still very unclear. I suppose when you mean the time is 24:00:00
        //that means the hours is 24, the minutes is 0 and the seconds is 0
        if(Hours < 24 || (Minutes == 0 && Seconds == 0)) Completedin24++;
      }
    }
