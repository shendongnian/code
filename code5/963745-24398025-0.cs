    public partial class Form1 : Form
    {
        ...
        ...
        private void ViewResults(IQueryable<Hero> viewResult)
        {
            dgdResult.DataSource = (from r in viewResult
                                    select new LittleHero
                                               {
                                                   Name = r.Name,
                                                   Rarity = r.Rarity,
                                                   Speed = r.Speed,
                                                   Attack = r.Attack,
                                                   Target = r.Target
                                               }).ToList();
        }
        private class LittleHero
        {
            public string Name { get; set; }
            public string Rarity { get; set; }
            public string Speed { get; set; }
            public string Attack { get; set; }
            public string Target { get; set; }
        }
    }
