    public interface IReadRepository<out TVehicle>
    {
        TVehicle GetItem(Guid id);
    }
    public interface IWriteRepository<in TVehicle>
    {
        void AddItem(TVehicle vehicle);
    }
