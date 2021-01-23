    String name = "James";
    name = name.Replace(' ',''); //removes spaces (if any entered)
    int len = string.Length;
    if(len%2 ==0)
    {
      //then it is an even number 
     len--; //if you want the 'slightly' left-er part. Else remove this if statement
    }
    if(len>=3)
    {
    String myThree = myThree.Substring(len-1,3);
    }
    else
    {
       if(len==0)
       {
          Messagebox.Show("No name entered");
       }
       else
       {
        myThree= name;
       }
    }
