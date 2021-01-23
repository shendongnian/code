    Public class BaseViewModel
    {
       //place your global properties here     
       Public string Name {get;set;}
     
    }
    Public class ViewModel1:BaseViewModel
    {
       //you can access the global property here
       void Method1()
       {
         Name="something";
       }
    }
    
     Public class ViewModel2:BaseViewModel
    {
       //you can access the global property here
       void Method2()
       {
         Name="something";
       }
    }
 
