    Player myPlayer = new Player();
    using (StreamWriter writer = File.CreateText("player.xml"))
    {
        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(myPlayer.GetTyper());
        x.Serialize(writer, myPlayer);
    }
