    public static Player loadUser(string ID)
        {
            var table = Select(dbConnection, "tbuser", "id = " + ID);
            Player player = new Player();
            foreach (DataRow row in table.Rows)
            {
                player.id = (int)row[0];
                player.Name = row[1].ToString();
                player.Image = (byte[])row[2];
                return player;
            }
            return null;
        }
