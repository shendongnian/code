     int test;
     string test1;
     if (filename.ToLower().Contains(".tif"))
     {
         test = 0;
     }
     else if (ValidExtension(filename.ToLower()))
     {
         test = 1; 
         test1 = "hello";
     }
