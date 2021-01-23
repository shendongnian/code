    DaysOfWeek selected = DaysOfWeek.None;
    foreach (DaysOfWeek item in list.CheckedItems)
    {
        selected = selected | item;
    }
    Console.WriteLine(selected.ToString()); // see what you've got checked
