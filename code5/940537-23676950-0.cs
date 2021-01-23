    public class SoundManager : MonoBehaviour {
    
    public List<AudioSource> audioSounds = new List<AudioSource>();
    public double minTime = 0.5;
    public static SoundManager Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
    }
    
    public void playSound(AudioClip sourceSound, Vector3 objectPosition, int volume, float audioPitch, int dopplerLevel)
    {
    
    
        bool playsound = false;
        foreach (AudioSource sound in audioSounds) // Loop through List with foreach
        {
    
    
            if (sourceSound.name != sound.name && sound.time <= minTime)
            {
                playsound = true;
            }
        }
    
    
        if(playsound) {
            AudioSource.PlayClipAtPoint(sourceSound, objectPosition);
        }
    
    }
    }
