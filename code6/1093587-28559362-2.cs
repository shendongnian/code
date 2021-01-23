    class Test<T> where T: IEnumerable<string>, ICollection<string>
    {
        public T Copy(T src)
        {
            List<string> result = new List<string>();
            foreach (var s in src as ICollection<string>)
                result.Add(s);
            return (T)(Object)result;
        }
        public void Print(T what)
        {
            foreach (var s in what as ICollection<string>)
                Console.WriteLine(s);
        }
    }
    ////////////////////////////////////////   
    Test<List<string>> t = new Test<List<string>>();
    t.Print(t.Copy(new List<string>() { "One", "Two" }));
