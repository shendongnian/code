    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        void LaunchServer() {
            Network.incomingPassword = "HolyMoly";
            bool useNat = !Network.HavePublicAddress();
            Network.InitializeServer(32, 25000, useNat);
        }
    }
