      public class MainViewModel
      {
         public string TeamID { get; set; }
    
         public MainViewModel()
         {
            Players = new ObservableCollection<PlayersViewModel>();
         }
         
         public void GetPlayer()
         {
            string url = "http://192.168.1.19/projects/t20lite/index.php/api/api/get_playersbyteam;"
            // Do something with url and tour TeamID
            var task = new HttpGetTask<PlayerList>(url, this.OnPostExecute);
            task.OnPreExecute = this.OnPreExecute;
            task.OnError = this.OnError;
    
            task.Execute();
         }   
      }  
