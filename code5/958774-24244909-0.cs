    static void Main()
        {
            string myInput = "Test";
            Action<string> del = new Action<string>(SomeMethod);
            del.BeginInvoke(
                "input parameter",
                (IAsyncResult ar) =>
                    {
                        Console.WriteLine("More Input parameters..." + myInput);
                        del.EndInvoke(ar);
                    },
                del);
        }
