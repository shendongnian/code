    var creditGrades = new[]
    {
        new { credit = credit1.Text, grade = grade1.Text },
        new { credit = credit2.Text, grade = grade2.Text },
        new { credit = credit3.Text, grade = grade3.Text }
    };
    var total = creditGrades.Aggregate(0, (i, x) =>
                    totalpointcalc(i, x.credit, x.grade));
