            var open = 8;
            var close = 22;
            var c = new DateTime(2014, 1, 1, open, 0, 0);
            var d = new DateTime(2014, 1, 1, close, 0, 0); ;
            while (c < d)
            {
                Console.WriteLine(string.Format("{0}:{1}", c.ToString("hh"), c.ToString("mm")));
                c = c.AddMinutes(15);
            }
