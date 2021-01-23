    void Main()
    {
        var test = new[]
        {
            new { name = "Test", id = 42 },
            new { name = "Test 2", id = 17 }
        }.ToList();
        CatData.Create(test);
    }
    
    public class CatData<T>
    {
        public CatData(List<T> list)
        {
        }
    }
    
    public static class CatData
    {
        public static CatData<T> Create<T>(List<T> list)
        {
            return new CatData<T>(list);
        }
    }
