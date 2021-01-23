    // Optional :-) You can ignore the logger and live happy...
    // Not optional: you can live happy very far from me!
    SafeQueryable.Logger = (iqueriable, expression, e) => Console.WriteLine(e);
    var q1 = context.Items.AsSafe();
    var q2 = q1.Where(x => x.ID.GetHashCode() > 0);
    var q3 = q2.Select(x => x.ID);
    var ex = ((ISafeQueryable)q3).Exception;
