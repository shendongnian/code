    public class StoreData : MonoBehaviour {
    
        // this will hold your data (but in the snippets you provided I 
        // can't see how you are accessing this, maybe this should be public)
        private static SaveInformation saveInformation = null; // keep one instance
        private static string savepath = Application.dataPath; // or Application.persistentDataPath ?
        private static string savePathFile = Path.Combine(savepath, "SaveInformation.xml");
        public SaveInformation Instance {
           get {
               return (saveInformation ?? new SaveInformation());
           }
        }
        public static void Load(){
            saveInformation = SaveInformation.Load(savePathFile);
            Debug.Log("Loaded");
        }
    
        public static void Save(){
            if (saveInformation != null) {
               saveInformation.Save(savePathFile);
               Debug.Log("Saved");
            } else {
                Debug.Log("No saveinformation yet");
            }
        }
    }
