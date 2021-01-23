    // Boolean values don't need = true
    if(tTime.HasValue){
       Console.WriteLine(tTime.Value.ToString("hh:mm tt"));
    }else{
       Console.WriteLine(String.Empty);
    }
