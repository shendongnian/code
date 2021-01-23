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
    var itemValue = default(int);
    if(int.TryParse(item.value, out itemValue)){
      if(itemValue >= 1 && itemValue <= 25){
        //match.
      }else{
        //error.
      }
    }else{
      //item.value is not numeric.
    }
