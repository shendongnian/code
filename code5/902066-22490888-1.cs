    public static string GetMLBID(int fk_players_id) {
        using (MLBDataClassesDataContext context = new MLBDataClassesDataContext())
        {
            var query = (from a in context.players
                         where a.fk_player_type_id == fk_players_id
                         select a).ToList();
            foreach (var b in query)
            {
                Console.WriteLine(b.first_name);
            }
        }
    }
