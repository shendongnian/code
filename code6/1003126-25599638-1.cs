    public abstract class Vehicle : IComparable<Vehicle>, IComparable {
    public Int16 AccidentID { get; set; }
    public DateTime ProductionDate { get; set;}
    public Vehicle(Int16 _ Vehicle ID,DateTime _ProductionDate)
    {
        this.AccidentID = _ AccidentID;
        this.ProductionDate = _ProductionDate;
    }
    int IComparable.CompareTo(object other) {
        return CompareTo((Vehicle)other);
    }
    public int CompareTo(Vehicle other){
        return this.ProductionDate.CompareTo(other.ProductionDate);
    }
    public Vehicle()
    {}
