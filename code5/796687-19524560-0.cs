    public partial class MainUI : Form {
       //...
       public class RequireShowMovieEventArgs : EventArgs {
         public string MoviePath {get;set;}
       }
       public delegate void RequireShowMovieEventHandler(object sender, RequireShowMovieEventArgs e);
       public static event RequireShowMovieEventHandler RequireShowMovie;
       //...
    }
    //just fire the event when you want to show/change the movie
    RequireShowMovieEventHandler handler = MainUI.RequireShowMovie;
    if(handler != null) handler(yourObject, new MainUI.RequireShowMovieEventArgs{ MoviePath = @"D:\football scoreboard project\football scoreboard\footballscoreb    \quran.swf"});
    //Your display form (which you call flashForm)
    public class FlashForm : Form {
     public FlashForm(){
       MainUI.RequireShowMovie += (s,e) => {
          MOVIE = e.MoviePath;
          axShockwaveFlash1.Show();
       };
     }
     //....
    }
