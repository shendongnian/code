            DateTime start = DateTime.Now;
            //using (FileStream fs = new FileStream(@"C:\temp\x.x", FileMode.Append, FileAccess.Write, FileShare.Write, 1, true))
            //{
            //    for (int row = 1; row < 3 * 1000; row++)
            //    {
            //        for (int column = 1; column < 3 * 1000; column++)
            //        {
            //            byte[] bytes = Encoding.ASCII.GetBytes(1.ToString() + ",");
            //            fs.Write(bytes, 0, bytes.Length);
            //        }
            //        byte[] bytes2 = Encoding.ASCII.GetBytes("\n");
            //        fs.Write(bytes2, 0, bytes2.Length);
            //    }
            //}
            using (TextWriter tw = new StreamWriter(new FileStream(@"C:\temp\x.x", FileMode.Append, FileAccess.Write, FileShare.Write, 1, true)))
            {
                for (int row = 1; row < 3 * 1000; row++)
                {
                    for (int column = 1; column < 3 * 1000; column++)
                    {
                        tw.Write(1.ToString());
                        tw.Write(',');
                    }
                    tw.WriteLine();
                }
            }
            DateTime end = DateTime.Now;
            MessageBox.Show(string.Format("Time spent: {0:N0} ms.", (end - start).TotalMilliseconds));
