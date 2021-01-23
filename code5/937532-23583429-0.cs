    using System.Windows.Controls
    namespace MP3Strip
    { 
      public class listViewDoubleBuffered : ListView
      {
          public listViewDoubleBuffered()
          {
              this.DoubleBuffered = true;
          }
       }
    }
