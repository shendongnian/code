    public class TestClass : IRequest
    {
        public void Failed(string Error)
        {
           //do something here
        }
        
        public void Succeeded(string ItemId);
        {
           //do something here
        }
    }
    
    //Calling your method
    TestClass mySecondPara = new TestClass();
    
    PlaceItem(item, mySecondPara)
