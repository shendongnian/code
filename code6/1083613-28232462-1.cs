      void onTick(object sender, EventArgs e)
        {
            List<String> tempList = new System.Collections.Generic.List<String>();
    
            foreach(String item in waitingForClose){
                
                  try
                  {
                        System.IO.File.Copy(System.IO.Path.GetFullPath(item), @"C:\Users\myuser\Desktop\Repo\" + System.IO.Path.GetFileName(item), true);
                        tempList.Add(item);
                    }
                    catch  {
                        // Do nothing
                    }
                }
            waitingForClose.RemoveAll(i => tempList.Contains(i));
        }
