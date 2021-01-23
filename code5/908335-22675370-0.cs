    if (userseq==0)
    {
      MessageBox.Show("This User ID Does Not Exist");
    }
    else
    {
       var results = new List<float>(1143600);
       for (int z = 0; z < 1143600; z++)
       {
         results.Add(dotproduct(userseq, z));
       }
    }
