    [Serializable]
    public class MyBigViewModel : IValidatableObject 
        {
           public MyBigViewModel(){
              MyOtherViewModel = new MyOtherViewModel();
              MyThirdViewModel = new MyThirdViewModel();
          }
          public MyOtherViewModel {get;set;}
          public MyThiddViewModel {get;set;} 
        public void Post(){
               //you can do something here based on post back 
               //like maybe this where the post method here processes new data
               MyOtherViewModel.Post();
        }
           
    }
