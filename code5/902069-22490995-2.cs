    public static string GetMLBID(int fk_players_id)
    {
        using (MLBDataClassesDataContext context = new MLBDataClassesDataContext())
        {
            var query = context.players
                      .Where(a => a.fk_player_type_id == fk_players_id);
        
            foreach (var b in query)
            {
                Console.WriteLine(b.mlb_com_id);
            }
        }
    }
