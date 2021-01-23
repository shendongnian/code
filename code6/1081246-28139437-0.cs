    public static class Skill
    {
        public static int Level0Count(this WebGridRow webGridRow)
        {
             // extension method code here
            return SkillLevelStaffs.Where(a => a.Level.Name.Contains("0")).Count();
        }
    }
