    public class Foo
    {
        List<bus> bus_list_2d=new List<bus>();
        public void AddBus(string channel, params string[] labels)
        {
            bus_list_2d.Add(new bus()
            {
                channel=channel,
                label=new List<string>(labels)
            });
        }
    }
    public class bus
    {
        public string channel { get; set; }
        public List<String> label { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo=new Foo();
            foo.AddBus("ABC", "A", "B", "C");
        }
    }
