    Console.WriteLine("Enter 1, 2, 3, OR 4");
    while( true ){
       uI = int.Parse(Console.ReadLine());
       string message = string.Empty;
       switch( uI ){
          case 1: message = "msg"; break;
          case 2: message = "msgg"; break;
          case 3: message = "msggg"; break;
          case 4: message = "msgggg"; break;
          default: break;
       }
       if(message != string.Empty)
          Console.WriteLine(message);
       
       Console.WriteLine("SELECT 1, 2, 3, OR 4");
    }
