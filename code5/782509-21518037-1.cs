    public class Eve
    {
        // Eve can't write that, it won't compile:
        // 'Alice.Alice()' is inaccessible due to its protection level
        private class EvePrivateKey : Alice, IKey { }
        public void PublicSendMesssageToBob() {
            // Eve can't write that either:
            // 'Alice.AlicePrivateKey' is inaccessible due to its protection level
            Bob.Create().FriendRecieveMessageFromAlice<Alice.AlicePrivateKey>(42);
        }
    }
