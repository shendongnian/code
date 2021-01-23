    public class MyViewModel : ViewModelBase {
        public PlayerData PlayerData {
            get { return iPlayerData; }
            set { 
                iPlayerData = value;
                OnPropertyChanged( "PlayerData" );
            }
        }
        private PlayerData iPlayerData;
        // Other properties & code
    }
