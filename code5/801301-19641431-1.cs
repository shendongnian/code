    try{
      if((int)item.value >= 1 && (int)item.value <=25){
        //match.
      }else{
        //error.
      }
    }catch (Exception e){
      //type error
    }
    //or---
    if(int.TryParse(item.value)){
      if(int.Parse(item.value) >= 1 && int.Parse(item.value) <=25){
        //match.
      }else{
        //error.
      }
    }else{
      //item.value is not numeric.
    }
