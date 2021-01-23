    using System.Text;
    
    //converts string/char into ASCII
    byte[] encoding = System.Text.ASCIIEncoding.ASCII.GetBytes("Hello, World!");
    
    //converts ASCII into string
    Console.Write(Encoding.ASCII.GetString(encoding));
