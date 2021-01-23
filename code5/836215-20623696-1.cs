    using System.Threading.Tasks;
    
    ...
    // note we need to declare the method async as well
    public async void Button1_Click(object sender, EventArgs args)
    {
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
    }
