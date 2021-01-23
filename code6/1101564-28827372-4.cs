    //fill the listBoxes
    for (double i = 0; i <= 90; i++)
    {
       k = Math.PI / 180;
       z = Math.Tan((i / 2 + 45) * k);
    
       x = (d / 3.141) * (Math.Sin(Math.PI * i / 180) - Math.Log(z));
       y = d / 3.141 * (Math.Cos((Math.PI * i) / 180) + (3.141 / 2)); 
     
       listBox2.Items.Add(x);
       listBox1.Items.Add(y);
       listBox3.Items.Add(z);
    }
    
    // write the text file
    const string sPath = @"C:\Users\NET\Desktop\deneme.txt";
    using(StreamWriter SaveFile = new StreamWriter(sPath))
    {   
      foreach (int i=0; i<listBox1.Items.Count; i++)
      {
        string line = String.Format("{0},{1}", listBox1.Items[i], listBox2.Items[i]);
         SaveFile.WriteLine(line);
      }          
    }
