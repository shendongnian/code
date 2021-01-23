    foreach (var result in results) {
        var baseObj = result.BaseObject;
        if (baseObj is System.Diagnostics.Process)
        {
            var p = (System.Diagnostics.Process) baseObj;
            Console.WriteLine("Handles:{0}, NPM:{1}, PM:{2}, etc", p.HandleCount, p.NonpagedSystemMemorySize, p.PagedMemorySize);
        }
        else {
            Console.WriteLine(result);
        }
    }
