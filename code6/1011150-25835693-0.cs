    public void Console(List<Keys> keys)
            {
                clickNo ++;
    
                start = DateTime.Now;
                progressBar1.Maximum = 1;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
    
                switch (clickNo)
                {
                    case 1:
                        DoRequest(ScreenshotRequest.DannysCommands.NormalOperation); 
                        break;
                    case 2:
                        DoRequest(ScreenshotRequest.DannysCommands.Displayoverlays); 
                        break;
                    case 3:
                        DoRequest(ScreenshotRequest.DannysCommands.Dontdisplayoverlays); 
                        clickNo = 0;
                        break;
                }
            
            }
