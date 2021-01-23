     Process[] pp = Process.GetProcessesByName("explorer");
     ArrayList processIDs = new ArrayList();
     foreach (Process p in pp)
     {
          if(p.StartInfo.UserName == "user name")
          {
               p.kill();
               break; 
          }
     }
