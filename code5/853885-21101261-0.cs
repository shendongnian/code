    public interface IReadValues
    {
        string Val1 { get; }
        string Val2 { get; }
    }
    public class A
    {
        public int Index { get; set; }
        public IReadValues ConfigOne { get; set; }
        public IReadValues ConfigTwo { get; set; }
        public void SetConfigOne(string val1, string val2);
        public void SetConfigTwo(string val1, string val2);
    }
    public class B : IReadValues
    {
        public string Val1 { get; set; }
        public string Val2 { get; set; }
    }
