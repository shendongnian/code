    public string[] SelectedSkills { get; set; }
		public IEnumerable<SelectListItem> SkillList { get; set; }
		public MyModel()
		{
			SkillList = new List<SelectListItem>();
			((List<SelectListItem>)SkillList).Add(new SelectListItem { Text = "Skill 1", Value = "1" });
			((List<SelectListItem>)SkillList).Add(new SelectListItem { Text = "Skill 2", Value = "2" });
			((List<SelectListItem>)SkillList).Add(new SelectListItem { Text = "Skill 3", Value = "3" });
			((List<SelectListItem>)SkillList).Add(new SelectListItem { Text = "Skill 4", Value = "4" });
			SelectedSkills = new string[3];
			SelectedSkills[0] = "1";
			SelectedSkills[1] = "2";
			SelectedSkills[2] = "3";
		}
