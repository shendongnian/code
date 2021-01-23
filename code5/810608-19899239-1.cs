    public partial class MainGameWindow : Form
    { 
        //sets the room ID to the first room as default
        string roomID = "FirstRoom";
        //makes a list for the inventory
        //collection initializer way (thanks to Max bellow!)
        List<string> Inventory = new List<string>()
        {
            "A piece of string...Useless!",
        };
        //constructor way
        public MainGameWindow()
        {
            Inventory.Add("A piece of string...Useless!");
        }
        //method way
        public void MethodAddUselessString()
        {
            Inventory.Add("A piece of string...Useless!");
        }
        //function way
        public bool FunctionAddUselessString()
        {
            Inventory.Add("A piece of string...Useless!");
            return true;
        }    
    }
