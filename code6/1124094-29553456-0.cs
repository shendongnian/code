    if(lblDisplay.InvokeRequired) {
     lblDisplay.Invoke((Action)delegate{ lblDisplay.Visible = true; }); // For synchronous
     lblDisplay.BeginInvoke((Action)delegate{ lblDisplay.Visible = true; }) // For asynchronous
          }
    else
    {
    lblDisplay.Visible=true;
    }
