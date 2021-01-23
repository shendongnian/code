    public interface MemoryObject<T>
    {
         T FromMemory { get; }
         //... other properties and methods
    }
    public class MemoryObjectA : MemoryObject<List<string>> { ... }
    public class MemoryObjectB : MemoryObject<DataTable> { ... }
