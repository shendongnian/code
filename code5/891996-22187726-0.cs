    Class Window
            {
             Thread _thread = null;
            
             public void OnButtonClick()
             {
               _thread = CreateAndStartThread();
             }
            
             public void OnCloseWindow()
             {
               if(null != _thread){_thread.Wait();}
             }
            }
