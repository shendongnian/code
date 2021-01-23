    byte[] b = new byte[100];
    int k = s.Receive(b);
    Console.WriteLine("Recieved...");
    for (int i = 0; i < k; i++)
       Console.Write(Convert.ToChar(b[i]));
 
    String s = System.Text.Encoding.UTF8.GetString(byteArray);
    
    if("0".Equals(s)) {
      /* clean up */
       s.Close();
       myList.Stop();
    }
