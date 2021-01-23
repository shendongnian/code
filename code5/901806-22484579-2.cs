    public static class Achievements
        {
            private static string _stillBurning = "ach1_StillBurning.jpg";
            private static string _faster = "ach2_Faster.jpg";
            public static string AchievementsFile { get; set; }
            public static Image SetAchievementFromAchievementCode(int a)
            {
                Image answer;
                using (StreamWriter aw = new StreamWriter(Achievements.AchievementsFile))
                {
                    switch (a)
                    {
                        case 1:
                            aw.WriteLine(_stillBurning);
                            answer = Image.FromFile(ach1_StillBurning);
                            break;
                        case 2:
                            aw.WriteLine(_faster);
                            answer = Image.FromFile(ach2_Faster);
                            break;
                    }
                }
                return answer;
            }
            public static IEnumerable<string> ReadAchievements()
            {
                List<string> answer = new List<string>();
                using (StreamReader ar = new StreamReader(Achievements.AchievementsFile))
                {
                    while (!ar.EndOfStream)
                        answer.Add(ar.ReadLine());                    
                }
                return answer;
            }
        }
