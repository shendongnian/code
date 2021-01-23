    public interface IKnowThis {
    
       public bool IsTrue { get; set; }
    
    }
    
     public T testfunction<T, U>(U numb) where U : IKnowThis
        {
            switch(numb.IsTrue){
    
            }
            ....
        }
