        else
        {
            //if (!File.Exists(dailyLog))
            //{
            //      using (FS = File.Create(dailyLog)) { }
            //      FS.Close();
            //}
           
            using (FileStream FSAppend = new FileStream(dailyLog, FileMode.Append, FileAccess.Write))
            using (StreamWriter TXT_WRITE = new StreamWriter(FSAppend))
            {
              TXT_WRITE.WriteLine(msg);
            }
            //TXT_WRITE.Close();
            //FSAppend.Close();
        }
