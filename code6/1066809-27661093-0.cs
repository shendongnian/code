    static void Main(string[] args)
    {
        StreamReader f = new StreamReader("test.txt");
        int x, y, z;
        while (!f.EndOfStream)
        {
            int[] a = parse(f.ReadLine());
            x = a[0];
            y = a[1];
            z = a[2];
            //do what you want with x and y and z here I'll just print them
            Console.WriteLine("{0} {1} {2}", x, y, z);
        }
        f.Close();            
    }
    static int[] parse(string st)
    {
        int[] a = new int[3];
        a[0] = int.Parse(st.Substring(0, st.IndexOf(' ')));
        st = st.Remove(0, st.IndexOf(' ') + 1);
        a[1] = int.Parse(st.Substring(0, st.IndexOf(' ')));
        st = st.Remove(0, st.IndexOf(' ') + 1);
        a[2] = int.Parse(st);
        return a;
    }
