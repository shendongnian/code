            string test = "rahul";
            // Here ElapsedTicks = 1083
            Stopwatch watch = Stopwatch.StartNew();
            string test1 = test.ToUpper()[0] + test.Substring(1);
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            
            //Here ElapsedTicks = 297
            watch.Restart();
            string test2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(test.ToLower());
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
