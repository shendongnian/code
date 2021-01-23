            string strSubjectIDs = "20,19,18,17,16,15";
            Console.WriteLine(strSubjectIDs);
            Queue<Char> q = new Queue<Char>();
            Stack<Queue<Char>> s = new Stack<Queue<Char>>();
            foreach(Char c in (strSubjectIDs.Trim(',') + ",").ToCharArray())
            {
                q.Enqueue(c);
                if (c == ',')
                {
                    s.Push(q);
                    q = new Queue<char>();
                }
            }
            while(s.Count > 0)
            {
                Queue<Char> t = s.Pop();
                while(t.Count > 0)
                {
                    q.Enqueue(t.Dequeue());
                }
            }
            strSubjectIDs = new String(q.ToArray()).Trim(',');
            Console.WriteLine(strSubjectIDs);
