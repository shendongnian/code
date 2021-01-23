     public ObservableCollection<Level1> Load1(XElement root, out TimeSpan t1, out TimeSpan t2)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            var query = from l1 in root.Elements("level1")
                        select new Level1()
                        {
                            Children = new ObservableCollection<Level2>(
                                from l2 in l1.Elements("level2")
                                select new Level2()
                                {
                                    Children = new ObservableCollection<Level3>(
                                        from l3 in l2.Elements("level3")
                                        select new Level3())
                                })
                        };
            ObservableCollection<Level1> l1Collection = new ObservableCollection<Level1>(query);
            sp.Stop();
            t1 = sp.Elapsed;
            sp.Reset();
            sp.Start();
            foreach (Level1 l1 in query)
            {
                foreach (Level2 l2 in l1.Children)
                {
                    l2.Parent = l1;
                    foreach (Level3 l3 in l2.Children)
                    {
                        l3.Parent = l2;
                    }
                }
            }
            sp.Stop();
            t2 = sp.Elapsed;
            return l1Collection;
        }
        public ObservableCollection<Level1> Load2(XElement root, out TimeSpan t)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            ObservableCollection<Level1> l1Collection = new ObservableCollection<Level1>(
                root.Elements("level1").Select(xl1 =>
                {
                    Level1 l1 = new Level1();
                    l1.Children = new ObservableCollection<Level2>(xl1.Elements("level2").Select(xl2 =>
                    {
                        Level2 l2 = new Level2() { Parent = l1 };
                        l2.Children = new ObservableCollection<Level3>(xl2.Elements("level3").Select(xl3 =>
                            new Level3() { Parent = l2 }));
                        return l2;
                    }));
                    return l1;
                }));
            sp.Stop();
            t = sp.Elapsed;
            return l1Collection;
        }
        public void Test()
        {
            XElement root = XElement.Load("xmlfile2.xml");
            TimeSpan t1, t2, t3;
            Load1(root, out t1, out t2);
            Load2(root, out t3);
            System.Windows.MessageBox.Show(string.Format("t1={0}  t2={1}  t3={2}", t1, t2, t3));
        }
