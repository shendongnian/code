    AnswerEnum CheckEverything(Bigobj o)
    { 
       List<Func<AnswerEnum>> checkings = new List<Func<AnswerEnum>>
       {
         (obj)=>{return CheckFirstThing(obj);},
         (obj)=>{return CheckSecondThing(obj);}
       };
  
       foreach(var chk in checkings)
       {
          AnswerEnum answer;
          if((answer= chk(o))!=AnswerEnum.OK)
                return answer;
       }
       return AnswerEnum.OK;
    }
