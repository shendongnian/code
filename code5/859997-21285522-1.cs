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
             //if it is necessary to undo the most recent actions first, 
             //just reverse the list:
             completed.Reverse(); 
             completed.ForEach(x => x.ReverseWork());
        }
    }
              
       
