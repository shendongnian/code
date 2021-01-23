    public interface ICharacter {
        int myValue { get; set;}
        void myMethod();
    }
    public class BladeWarrior : ICharacter {
        private int myPrivateValue;
        public int myValue { get { return myPrivateValue; } set { myPrivateValue = value; } }
    
        public void myMethod() {
        //Do what you want
        }
    }
    ICharacter[] PlayerOne = new ICharacter[5];
    PlayerOne[0] = new BladeWarrior();
