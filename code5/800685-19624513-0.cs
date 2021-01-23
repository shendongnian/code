    var t1 = Task.Run(() => ReadFile(path1));
    var t2 = Task.Run(() => ReadFile(path2));
    var t3 = Task.Run(() => ReadFile(path3));
    Console.WriteLine("Sum: {0}", t1.Result + t2.Result + t3.Result);
    static int ReadFile(string path) {
        using(var file = new StreamReader(path))      
            return int.Parse(file.ReadLine());
    }
