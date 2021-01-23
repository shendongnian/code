    public class Foo
    {
        // TODO: Fix names to be more conventional and friendly
        string lia = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        StreamReader fileitem;
        public Foo()
        {
            fileitem=new StreamReader(Path.Combine(lia,"dataset.txt"));
        }
    }
