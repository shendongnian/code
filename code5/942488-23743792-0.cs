    tasks
        .Where(a => a.Username == ProgForm.ActiveForm.Text)
        .ForEach(a => 
            tdt.Rows.Add(a.Id, a.Name, a.Description, a.IsSolved, a.IsTested, a.Username)
        );
