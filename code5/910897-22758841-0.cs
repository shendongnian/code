    double totalTicks=0D;
    foreach(var x in Data){
       totalTicks=x.Time.Ticks;
    }
    double averageTicks=totalTicks / Data.Count();
    DateTime avgDateTime=new DateTime(averageTicks);
