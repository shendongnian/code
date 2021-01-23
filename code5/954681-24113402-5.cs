    using System.Linq;
    var frequency = cn
        .SelectMany(u => u.Split(new string[] { ", " }, StringSplitOptions.None))
        .GroupBy(s => s)
        .ToDictionary(g => g.Key, g => g.Count());
    var numberOfSkills = frequency.Count;
    var numberOfUsersWithSkillOne = frequency["SkillOne"];
