            string test = "rahul";
            Stopwatch watch = Stopwatch.StartNew();
            string test1 = test.ToUpper()[0] + test.Substring(1);
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            
            watch.Restart();
            string test2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(test.ToLower());
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
