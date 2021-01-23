    public class MyButton {
        public bool isClicked { get; }
        public Delegate action { get; }
    }
    foreach (var item in buttons) {
        if(item.isClicked)
            ((Action)item.action)(); // assuming that your "action" is a method which returns nothing and takes no arguments, cast to a more appropriate type if needed
    }
