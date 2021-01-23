    public class Player
    {
        public int id { get; set; }
        public int r { get; set; }
        public int n { get; set; }
        public string f { get; set; }
        public string l { get; set; }
        public string c { get; set; }
    }
    public class LegendsPlayer
    {
        public int id { get; set; }
        public int r { get; set; }
        public int n { get; set; }
        public string f { get; set; }
        public string l { get; set; }
        public string c { get; set; }
    }
    public class RootObject
    {
        public List<Player> Players { get; set; }
        public List<LegendsPlayer> LegendsPlayers { get; set; }
    }
    // Then you load int your comboBox
    private void LoadComboItems()
        {
            var str = File.ReadAllText(pathToYourFile);
            var x = JsonConvert.DeserializeObject<RootObject>(str);
            foreach (var player in x.Players)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = player.f + " " + player.l;
                item.Value = player.id;
                comboBox1.Items.Add(item);
            }        
        }
