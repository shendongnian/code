    using System.Threading.Tasks;
    
    ...
    if (await Task.Run(new Func<bool>(Operation1)))
    {
       richTextBox.AppendText("Operation1 finished");
    
       if (await Task.Run(new Func<bool>(Operation2)))
       {
          richTextBox.AppendText("Operation2 finished");
    
          if (await Task.Run(new Func<bool>(Operation3)))
          {
             richTextBox.AppendText("Operation3 finished");
          }
       }
    }
