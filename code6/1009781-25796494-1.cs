    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Timers;
    using System.Diagnostics;
    namespace nkraljica
    {
        public class NKraljicaMain
        {
            public static void Main(string[] args)
            {
                int n = 13;
                var stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                Abs.NKraljica.postaviKraljicuNaPlocu(n, Console.WriteLine);
                stopwatch.Stop();
                var consoleElapsed = stopwatch.Elapsed;
                stopwatch.Reset();
                stopwatch.Start();
                StringBuilder sb1 = new StringBuilder();
                Abs.NKraljica.postaviKraljicuNaPlocu(n, s => sb1.AppendLine(s));
                stopwatch.Stop();
                var sbElapsed = stopwatch.Elapsed;
                stopwatch.Reset();
                stopwatch.Start();
                string lastLine = null;
                Abs.NKraljica.postaviKraljicuNaPlocu(n, s => lastLine = s);
                stopwatch.Stop();
                var nologElapsed = stopwatch.Elapsed;
                stopwatch.Reset();
                stopwatch.Start();
                StringBuilder sb2 = new StringBuilder();
                Inline.NKraljica.postaviKraljicuNaPlocu(n, s => sb2.AppendLine(s));
                stopwatch.Stop();
                var inlineElapsed = stopwatch.Elapsed;
                Debug.Assert(sb1.ToString() == sb2.ToString());
                Console.WriteLine(string.Format("Console logging time = {0}", consoleElapsed));
                Console.WriteLine(string.Format("StringBuilder logging time = {0}", sbElapsed));
                Console.WriteLine(string.Format("Dummy logging time = {0}", nologElapsed));
                Console.WriteLine(string.Format("Inline Abs + StringBuilder logging time = {0}", inlineElapsed));
                Console.ReadLine();
            }
        }
    }
    namespace nkraljica.Abs
    {
        public class NKraljica
        {
            public static void postaviKraljicuNaPlocu(int n, Action<string> reportFunc)
            {
                int[] ploca = new int[n];
                postaviKraljicuNaPlocu(0, ploca, reportFunc);
            }
            private static void postaviKraljicuNaPlocu(int Ki, int[] ploca, Action<string> reportFunc)
            {
                int n = ploca.Length;
                if (Ki == n)
                {
                    reportFunc(ploca.Aggregate(new StringBuilder(), (sb, i) => sb.Append(i)).ToString());
                }
                else
                {
                    for (int kolona = 0; kolona < n; kolona++)
                    {
                        if (jeLiSigurnoMjesto(kolona, Ki, ploca))
                        {
                            ploca[Ki] = kolona;
                            postaviKraljicuNaPlocu(Ki + 1, ploca, reportFunc);
                            ploca[Ki] = -1;
                        }
                    }
                }
            }
            private static bool jeLiSigurnoMjesto(int kolona, int Ki, int[] ploca)
            {
                for (int i = 0; i < Ki; i++)
                {
                    if (ploca[i] == kolona)
                    {
                        return false;
                    }
                    if (Math.Abs(ploca[i] - kolona) == Math.Abs(i - Ki))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
    namespace nkraljica.Inline
    {
        public class NKraljica
        {
            public static void postaviKraljicuNaPlocu(int n, Action<string> reportFunc)
            {
                int[] ploca = new int[n];
                postaviKraljicuNaPlocu(0, ploca, reportFunc);
            }
            private static void postaviKraljicuNaPlocu(int Ki, int[] ploca, Action<string> reportFunc)
            {
                int n = ploca.Length;
                if (Ki == n)
                {
                    reportFunc(ploca.Aggregate(new StringBuilder(), (sb, i) => sb.Append(i)).ToString());
                }
                else
                {
                    for (int kolona = 0; kolona < n; kolona++)
                    {
                        if (jeLiSigurnoMjesto(kolona, Ki, ploca))
                        {
                            ploca[Ki] = kolona;
                            postaviKraljicuNaPlocu(Ki + 1, ploca, reportFunc);
                            ploca[Ki] = -1;
                        }
                    }
                }
            }
            private static bool jeLiSigurnoMjesto(int kolona, int Ki, int[] ploca)
            {
                for (int i = 0; i < Ki; i++)
                {
                    if (ploca[i] == kolona)
                    {
                        return false;
                    }
                    int diff1 = ploca[i] - kolona;
                    int diff2 = i - Ki;
                    if (diff1 == diff2 || diff1 == checked(-diff2))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
