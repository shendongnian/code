    try
    {
          process.Start();
          process.WaitForExit();
          if (process.ExitCode >0)
          {
              MessageBox.Show(String.Fromat("print failed:{0} ", process.ExitCode ));
          }
    }
    catch (Exception ex)
    {
          MessageBox.Show(ex.Message);
    }
