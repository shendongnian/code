    public interface IReversableStep
    {
        void DoWork();
        void ReverseWork();
    }
---
    public void DoEverything()
    {
        var steps = new List<IReversableStep>()
        {
             new CreateUserFTPAccount(),
             new CreateUserFolder(),
             ...
        }
        var completed = new List<IReversableStep>();
        try 
        {
             foreach (var step in steps)
             {
                  step.DoWork();
                  completed.Add(step);
             }
        }
        catch (Exception)
        {
             completed.ForEach(x => x.ReverseWork());
        }
    }
              
       
