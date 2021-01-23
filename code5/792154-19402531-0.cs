    AnswerEnum CheckEverything(Bigobj o)
    { 
       List<Action<AnswerEnum>> checkings = new List<Action<AnswerEnum>>
       {
         (obj)=>{return CheckFirstThing(obj);},
         (obj)=>{return CheckSecondThing(obj);},
         (obj)=>{return CheckThirdThing(obj);},
       };
  
       foreach(var chk in checkings)
       {
          AnswerEnum answer;
          if((answer= chk(o))!=AnswerEnum.OK)
                return answer;
       }
       return AnswerEnum.OK;
    }
