    public class Quest
    {
        public int m_hero { get; set; }
        public double m_complete { get; set; }
    }
    private static void Main()
    {
        const int m_heronbr = 10;
        List<Quest> m_quests = new List<Quest>
        {
            new Quest {m_complete = 50, m_hero = m_heronbr},
            new Quest {m_complete = 75, m_hero = m_heronbr},
            new Quest {m_complete = 100, m_hero = m_heronbr}
        };
        var curentQuests =
            from a in m_quests
            where a.m_hero == m_heronbr
                  && a.m_complete != 100
            select a;
        Console.WriteLine(curentQuests.Count());
    }
