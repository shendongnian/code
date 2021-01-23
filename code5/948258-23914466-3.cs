    struct Age
    {
        public int Years, Months, Days; //It's a small struct, properties aren't necessary
        public Age(int years, int months = 0, int days = 0) { this.Years = years; this.Months = months; this.Days = days; }
    }
