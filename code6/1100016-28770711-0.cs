	List itemsToRemove = new List();
    foreach (var studentGroup in studentTestGroup.Where(t => t.students.Count() > 1 || t.students.Any(x => x.Retest == "Y")))
    {
        int countNo = studentGroup.students.Count(t => t.Retest == "N" || t.Retest == "");
        bool anyYes = studentGroup.students.Any(t => t.Retest == "Y");
        if (anyYes && countNo == 1)
        {
            var studentToKeep = studentGroup.students.Single(t => t.Retest == "N" || t.Retest == "");
            itemsToRemove.AddRange(t => t.STI == studentGroup.STI && t.TestName == studentGroup.TestName && t.PrimaryKey != studentToKeep.PrimaryKey);
        }
        else if (anyYes && countNo > 1)
        {
            var studentsToKeep = studentGroup.students.Where(t => t.Retest == "N" || t.Retest == "");
            itemsToRemove.AddRange(t => t.STI == studentGroup.STI && t.TestName == studentGroup.TestName && !studentsToKeep.Any(x => x.PrimaryKey == t.PrimaryKey));
        }
        else if (anyYes && countNo == 0)
        {
            itemsToRemove.AddRange(t => t.STI == studentGroup.STI && t.TestName == studentGroup.TestName && Convert.ToInt32(t.TestScaledScore) < 400);
        }
    }
	foreach (var itemToRemove in itemsToRemove)
	{
	    this.Remove(itemToRemove);
	}
