    public class CustomerViewModel
    {
       .....
       
       public CutomerViewModel Clone()
       {
          return (CustomerViewModel)MemberwiseClone();
       }
    
       .....
    }
