    public class ThreadObj
    {
    public int smallest {get;set;}
    public int biggest {get;set;}
    }
    public void Add(object obj)
    {
    ThreadObj myObj = (ThreadObj)obj;
      for (int i = myObj.smallest; i < myObj.biggest+1; i++)
      {
        Thread.Sleep(500);
        result = result + i;
      }
    }
    static void Main()
        {
          Thread t=new Thread(Add);
          t.start(new ThreadObj(){ smallest = 10, biggest = 100});
        }
