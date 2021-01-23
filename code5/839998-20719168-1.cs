    public class Request : IRequest
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
    Request mySecondPara = new Request();
    
    PlaceItem(item, mySecondPara)
