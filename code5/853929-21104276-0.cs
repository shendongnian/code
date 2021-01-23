    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data.OleDb;
    namespace WordFileGeneratorFromTextFileConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string textfileName = "varsDefinations.txt";
                    string wordfileName = "ATemplate.doc";
                    string fileNameWithPath = @"C:\Quotations\" + wordfileName;
                
                    CustomMessage aMesssage = new CustomMessage();
                    //Reading from text file
                    using (FileStream fs =
                        new FileStream(@"C:\Quotations\" + textfileName,FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        StreamReader sr = new StreamReader(fs);
                        string temp = sr.ReadToEnd();
                        string[] temparr = temp.Split('-');
                        for (int i = 0; i < temparr.Length;i++ )
                        {
                            string s = temparr[i];
                            if (s.Contains('\r'))
                            {
                                s = s.Replace('\r', ' ');
                            }
                            if (s.Contains('\n'))
                            {
                                s = s.Replace('\n', ' ');
                            }
                            temparr[i] = s;
                        }
                        if (temparr != null)
                        {
                            aMesssage.HeaderMessage = temparr[0];
                            aMesssage.MainMessage = temparr[1];
                            aMesssage.MessageSender = temparr[2];
                        }
                        sr.Close();
                    }
                    //Writing to word document
                    using (FileStream fs = new FileStream(fileNameWithPath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(aMesssage.HeaderMessage);
                        sw.WriteLine(aMesssage.MainMessage);
                        sw.WriteLine(aMesssage.MessageSender);
                        sw.Close();
                    }
                    //Opening Word Document
                    System.Diagnostics.Process.Start(fileNameWithPath);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message.ToString());
                }
            }
        }
        class CustomMessage
        {
            public string HeaderMessage { get; set; }
            public string MainMessage { get; set; }
            public string MessageSender { get; set; }
        }
    }
