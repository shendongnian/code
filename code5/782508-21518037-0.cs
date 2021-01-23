    public interface IKey { }
    public class Alice
    {
        // Alice, Bob and Carol must only have private constructors, so only nested classes can subclass them.
        private Alice() { }
        public static Alice Create() { return new Alice(); }
        private class AlicePrivateKey : Alice, IKey { }
        public void PublicSendMessageToBob() {
            Bob.Create().FriendRecieveMessageFromAlice<AlicePrivateKey>(42);
        }
        public void FriendRecieveMessageFromBob<TKey>(int message) where TKey : Bob, IKey {
            System.Console.WriteLine("Alice: I recieved message {0} from my friend Bob.", message);
        }
    }
    public class Bob
    {
        private Bob() { }
        public static Bob Create() { return new Bob(); }
        private class BobPrivateKey : Bob, IKey { }
        public void PublicSendMessageToAlice() {
            Alice.Create().FriendRecieveMessageFromBob<BobPrivateKey>(1337);
        }
        public void FriendRecieveMessageFromAlice<TKey>(int message) where TKey : Alice, IKey {
            System.Console.WriteLine("Bob: I recieved message {0} from my friend Alice.", message);
        }
    }
    
    class Program
    {
        static void Main(string[] args) {
            Alice.Create().PublicSendMessageToBob();
            Bob.Create().PublicSendMessageToAlice();
        }
    }
