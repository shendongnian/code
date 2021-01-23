    private int A;
    private string B;
    private double C;
    public void Initialize(DataObject data)
    {
        A = data.A;
        B = data.B;
        C = data.C;
    }
    public void DoSomething() //Just an arbitrary method using the data
    {
        return B + " " + A.ToString();
    }
