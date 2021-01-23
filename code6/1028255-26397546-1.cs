    public class ScoreClass: MonoBehaviour 
    {
        // Save.
        void SaveScore(int score) 
        {
            PlayerPrefs.SetInt("Player Score", score);
        }
        // Retrieve.
        void PrintScore()
        {
            print(PlayerPrefs.GetInt("Player Score"));
        }
    }
