    var predicate = PredicateBuilder.True<Employee>();
    if (textBox1.Text != "") {
        var txt = textBox1.Text;
        predicate = predicate.And(e => e.Field1ToQuery.Contains(txt));
    }
    if (textBox2.Text != "") {
        var txt = textBox2.Text;
        predicate = predicate.And(e => e.Field2ToQuery.Contains(txt));
    }
    var AWE = new AdventureWorks2008R2Entities();
    var query = AWE.Employees.AsExpandable().Where(predicate);
