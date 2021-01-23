      If (uiTrace.InvokeRequired && !uiTrace.Disposing && !uiTrace.IsDisposed)
      {
          uiTrace.BeginInvoke(gui);
          return;
      }
      Else
          gui();
