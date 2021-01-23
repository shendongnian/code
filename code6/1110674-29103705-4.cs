    public sealed class MyClass : IEnumerable<XElement>, IDisposable
    {
        public readonly XmlReader Reader;
        public MyClass(XmlReader reader)
        {
            Reader = reader;
        }
        
        // Sealed class
        public void Dispose()
        {
            Reader.Dispose();
        }
        public IEnumerator<XElement> GetEnumerator()
        {
            while (Reader.ReadToFollowing("PAR"))
            {
                yield return XElement.Load(Reader.ReadSubtree());
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    private static void readParameters(XmlReader m, Measurement meas)
    {
        var enu = new MyClass(m);
        Parallel.ForEach(enu, reader =>
        {
            // You do the work here 
        });
    }
