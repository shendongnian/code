    public partial class MainGameWindow : Form
    { 
        //sets the room ID to the first room as default
        string roomID = "FirstRoom";
        //makes a list for the inventory
        List<string> Inventory = new List<string>();
        public MainGameWindow()
        {
            Inventory.Add("A piece of string...Useless!");
        }
    
    }
