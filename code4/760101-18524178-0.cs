    private void btnNext_Click(object sender, EventArgs e)
    {
        Double sword;
        
        var answer = this.sightWordsDB1DataSet.Kindergarten.Aggregate(
            new { Min = int.MaxValue, Max = int.MinValue },
            (a, b) => new
            {
                Min = Math.Min(a.Min, b.Field<int>("")),
                Max = Math.Max(a.Max, b.Field<int>(""))
            });
        int min = answer.Min;
        int max = answer.Max;
        Random rng = new Random();
        // The value to be matched.
        var selectedMatchingValue = rng.Next(min, max + 1);
        sword = this.sightWordsDB1DataSet.Kindergarten
            .Where(r => r.Field<int>("") == selectedMatchingValue)
            .Select(r => r.Field<double>("sword")) // change to the correct column name.
            .First();
        lblSightWord.Text = Convert.ToString(sword);
    }
