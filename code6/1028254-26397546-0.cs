    public class ScoreClass: MonoBehaviour 
    {
        // Save.
        void SaveScore() 
        {
            PlayerPrefs.SetInt("Player Score", 10);
        }
        // Retrieve.
        void PrintScore()
        {
            print(PlayerPrefs.GetInt("Player Score"));
        }
    }
