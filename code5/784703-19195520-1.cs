    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Diagnostics;
    using System.IO;
    namespace randomport
    {
        class Core
        {
            public static int[] usedPorts = new int[] { };
            public static int
                minval = 8001,
                maxval = 8129,
                chosenPort = 0,
                timeout = 10,
                temp = 1024;
            public static bool read = false;
            public static void Main(string[] args)
            {
                string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
                if (!Directory.Exists(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.txt")))
                {
                    Directory.CreateDirectory(String.Concat(path, "\\desktop\\TerrariaServer\\filebin"));
                    //  using (StreamWriter sw = File.CreateText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.txt"))) { }
                }
                if (!Directory.Exists(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\chosenport.cmd")))
                {
                    Directory.CreateDirectory(String.Concat(path, "\\desktop\\TerrariaServer\\filebin"));
                    using (StreamWriter sw = File.CreateText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\chosenport.cmd"))) { }
                }
                if (args.Length > 0)
                {
                    if (args[0] == "-noread")
                    {
                    }
                    else if (args[0] == "-read" || args[0] == "-default")
                    {
                        if (!read)
                        {
                            Read();
                            read = true;
                        }
                    }
                }
                else
                {
                    if (!read)
                    {
                        Read();
                        read = true;
                    }
                }
                if (args.Length >= 3)
                {
                    if (args[1] != "-default" || args[1] != "0")
                    {
                        int.TryParse(args[1], out temp);
                        if (temp > 1024 && temp < 65535)
                        {
                            minval = temp;
                        }
                    }
                    if (args[2] != "-default" || args[2] != "0")
                    {
                        int.TryParse(args[2], out temp);
                        if (temp > 1024 && temp < 65535)
                        {
                            maxval = temp;
                        }
                    }
                }
                RandGen();
            }
            public static void RandGen()
            {
                string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
                Random rand = new Random();
                chosenPort = rand.Next(minval, maxval);
                for (int i = 0; i < usedPorts.Length; i++)
                {
                    if (chosenPort != usedPorts[i])
                    {
                        Write();
                    }
                    else return;
                }
            }
            public static void Read()
            {
                string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
                if (!File.Exists(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.txt")))
                {
                    File.Create(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.txt"));
                }
                using (StreamReader sr = new StreamReader(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.txt")))
                {
                    string[] values = sr.ReadToEnd().Split(';');
                    usedPorts = new int[values.Length];//Initialize the array with the same length as values
                    for (int i = 0; i < values.Length; i++)
                    {
                        int.TryParse(values[i], out usedPorts[i]);
                    }
                }
            }
            public static void Write()
            {
                string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
                File.AppendAllLines(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.txt"), new string[] { chosenPort + ";" });
                using (StreamWriter sw2 = File.CreateText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\chosenport.cmd")))
                {
                    sw2.WriteLine("set port=" + chosenPort);
                }
                Environment.Exit(0);
            }
        }
    }
