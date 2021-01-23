    public interface IStaffRepository : IDisposable
    {
      Task SaveAsync();
      ...
      Task<Staff> FindStaffAsync(int id, byte[] timestamp);
    }
