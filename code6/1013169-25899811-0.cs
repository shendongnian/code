    struct PhoneNumber { … }
    partial interface Person
    {
        int Id { get; }
        string Name { get; }
        PhoneNumber PhoneNumber { get; }
    }
    partial interface Appointment
    {
        DateTime Date { get; }
        Person[] Participants { get; }
    }
