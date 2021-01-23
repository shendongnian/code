    public interface IDriver
    {
        bool Start();
        bool Stop();
        bool Read(uint[] signal1, uint[] signal2);
    }
