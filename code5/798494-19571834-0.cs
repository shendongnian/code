    private void Method1(int i)
    {
      if (this.InvokeRequired)
      {
        Invoke(new MethodInvoker(delegate() { Method1(i); }));
      }
      else
      {
        // Put your code here...
      }
    }
