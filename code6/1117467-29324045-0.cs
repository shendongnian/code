    @helpers listfiles(String ID, String CNumber,){
       var lstTrue = new List<>();
       var lstFalse = new List<>();
       foreach(Loopitem I in GetLoop("items")){
          if(I.GetValue("userId") == ID)
                lstTrue.Add(I);
          else
                lstFalse.Add(I);
        }
       if(lstTrue.Count()>0)
       {
          <ul> foreach(var I in lstTrue){<li>@I.GetValue("name")</li>}</ul>
       }
       if(lstFalse.Count()>0)
       {    
          <ul> foreach(var I in lstTrue){<li>@I.GetValue("name")</li>}</ul>
       }   
    } 
