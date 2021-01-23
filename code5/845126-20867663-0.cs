            DateTime start = DateTime.Now;
            //
            //using(FileStream fs = new FileStream(@"C:\temp\x.x", FileMode.Append, FileAccess.Write, FileShare.Write, 1, true))
            //{
            //    for (int row = 1; row < 300; row++)
            //    {
            //        for (int column = 1; column < 20; column++)
            //        {
            //            byte[] bytes = Encoding.ASCII.GetBytes(1.ToString() + ",");
            //            fs.Write(bytes, 0, bytes.Length);
            //        }
            //        byte[] bytes2 = Encoding.ASCII.GetBytes("\n");
            //        fs.Write(bytes2, 0, bytes2.Length);
            //    }
            //}
            //
            StringBuilder sb = new StringBuilder();
            for (int row = 1; row < 300; row++)
            {
                for (int column = 1; column < 20; column++)
                {
                    sb.Append(1.ToString());
                    sb.Append(',');
                }
                sb.AppendLine();
            }
            File.AppendAllText(@"C:\temp\x.x", sb.ToString());
            DateTime end = DateTime.Now;
            MessageBox.Show(string.Format("Time spent: {0:N0} ms.", (end - start).TotalMilliseconds));
