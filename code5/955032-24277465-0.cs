    public List <Deduction > DeductionDetails
    {
        get { return (List<Deduction>)dgEmployeeDeductions.DataSource; }
        set { dgEmployeeDeductions.DataSource = value; }
    }
