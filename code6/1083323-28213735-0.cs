    public class Countdown
    {
         int _count;
         Action _onZero;
         
         public Countdown(int startValue, Action onZero)
         {
              _count = startValue;
              _onZero = onZero;
         }
   
         public void Tick()
         {
             if(_count == 0)
                 return; //or throw exception
             _count--;
             if(_count == 0)
                _onZero();
         }
    }
