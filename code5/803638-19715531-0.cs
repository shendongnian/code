    public class IPodHandler {
        [DllImport("__Internal")]
        private static extern void RegisterUnityIPodCallbackListener (string gameObject, string method);
        public static void MyRegisterUnityIPodCallbackListener () {
           if (Application.platform == RuntimePlatform.IPhonePlayer) {
               RegisterUnityIPodCallbackListener (GAME_OBJECT, METHOD);
           }
        }
    }
