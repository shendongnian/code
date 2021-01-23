    public class LeapHandler : MonoBehaviour {
        // Use this for initialization
        void Start () {
            LeapInput.Controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
        }
	
	// Update is called once per frame
        void Update () {
            LeapInput.Update();
            Frame thisFrame = LeapInput.Frame;
            for (int i = 0; i < thisFrame.Gestures().Count; i++)
            {
                Gesture gesture = thisFrame.Gesture(i);
                Debug.Log(gesture.Id);
            }
        }
        #if UNITY_STANDALONE_WIN
            [DllImport("mono", SetLastError=true)]
            static extern void mono_thread_exit();
        #endif
	
        void OnApplicationQuit() {
            #if UNITY_STANDALONE_WIN && !UNITY_EDITOR && UNITY_3_5
                mono_thread_exit ();
            #endif
        }
    }
