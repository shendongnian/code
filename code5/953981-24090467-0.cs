    for (int i = 0; i < N; i++)
    {
           Console.Write(position[i] + " ");
    
           Console.WriteLine("Hello World");
           FileStream fs = new FileStream("Test.txt", FileMode.Create);
           StreamWriter sw = new StreamWriter(fs);
           Console.SetOut(sw);
           Console.WriteLine(position[i] + " "); 
           sw.Close();
           sum += 1;
     }
