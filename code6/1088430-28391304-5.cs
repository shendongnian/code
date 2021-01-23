     //* from your class of your main frame
       //* this is where SetStatus is defined
       //* start a thread to process whatever task 
       //* is being done
    
       Thread t  = new Thread(StartProc);
       t.Start();
    
    
       public void StartProc()
       {
          //* start processing something, 
          //*let's assume your are processing a bunch of files
          List<string> fileNames;
          for (int i = 0; i < fileNames.Count; i++)
          {
             //* process file here
             //* ...........
    
         	 //* then update progress bar
             SetProgress((int)((i + 1) * 100 / fileNames.Length));
    	  }
    
          //* thread will exit here
    	}
