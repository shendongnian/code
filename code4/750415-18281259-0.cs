        string resultText = e.Result.Text.ToLower();
          if (resultText == "computer")
            {
              string myComputerPath = Environment. (Environment.SpecialFolder.MyComputer);
              System.Diagnostics.Process.Start("explorer", myComputerPath);
            //System.Diagnostics.Process.Start("explorer", "::{20d04fe0-3aea-1069-a2d8-08002b30309d}");
           }
