    class BotRand
     {
       //Write Event is delegate
       public execute(WriteEvent writeFx)
        {
         //Crawl
         writeFx("message");
        }
     } 
     class MainWindow : Window
     {
          void WriteFunc(object message, EventArgs outline) 
           {
                Dispatcher.Invoke(new Action(() => richText.AppendText(message));
           }
     }
