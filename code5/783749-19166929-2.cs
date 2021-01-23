    public class StatsConverter : ITypeConverter<Tuple<Player, Stats>, StatsModel>
    {
        public StatsModel Convert(Tuple<Player, Stats> source)
        {
            return new StatsModel
                   {
                       Id = source.Item2.Id,
                       PlayerId = source.Item1.Id,
                       DisplayName = source.Item2.DisplayName,
                   };
        }
    }
