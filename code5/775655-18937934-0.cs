    public interface I_Group<T, S>
        where T : I_Segment<S>
        where S : I_Complex
    {
        T Segment { get; set; }
    }
