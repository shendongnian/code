    void checkDIR(string Path)
    {
    //Path will equal AddImage right? 
       foreach(string childpath in Directory.GetDirectories(path))
        {
             //so here we are calling checkpaths for 7E GUID Directory Structure
             checkpaths(childpath);
        }
    }
    void checkpaths(string Path)
    {
          
       foreach(string childpath in Directory.GetDirectories(path))
        {  //here we dig deeper
             checkpaths(childpaths);//recursion
        }
        //the first recursion to get here will be the deepest directory
       //we are now in '14'
       if(there are any files)
       {do what you want}
       else
       {
        do what you need
       }
       
    }
