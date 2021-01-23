    foreach (var input in form.forminputs.ToArray())
    {
        db.Entry(input).State = EntityState.Deleted;
    }
    // form.forminputs.Clear();
