    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Globalization;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sourceDir = "D:\\testFile.txt",
                       outDir = "D:\\result.txt";
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
    
                using (StreamReader sr = new StreamReader(sourceDir))
                {
                    int divider = 5;
                    string line = sr.ReadLine();
                    StreamWriter sw = new StreamWriter(outDir);
    
                    List<string> listLine = new List<string>();
                    List<double> listOpen = new List<double>();
                    List<double> listHigh = new List<double>();
                    List<double> listLow = new List<double>();
                    List<double> listClose = new List<double>();
                    List<double> listVolume = new List<double>();
                    DateTime dateTimeOut = new DateTime();
                    string formatDate = "yyyyMMddHHmmss";
                    string newLine = "";
                    double priceOpen, priceHigh, priceLow, priceClose, volume;
    
                    //read first line, but don't write it
                    line = sr.ReadLine();
    
                    double highMax = double.MinValue;
                    double lowMin = double.MaxValue;
                    double volumeMax = double.MinValue;
    
                    while (line != null)
                    {
                        listLine = line.Split(',').ToList();
                        dateTimeOut = DateTime.ParseExact(listLine[1] + listLine[2], formatDate, null);
    
                        double.TryParse(listLine[3], out priceOpen);
                        double.TryParse(listLine[4], out priceHigh);
                        double.TryParse(listLine[5], out priceLow);
                        double.TryParse(listLine[6], out priceClose);
                        double.TryParse(listLine[7], out volume);
    
                        listOpen.Add(priceOpen);
                        listHigh.Add(priceHigh);
                        listLow.Add(priceLow);
                        listClose.Add(priceClose);
                        listVolume.Add(volume);
    
                        /*Here is implementation of accumulative max/min calculation*/
                        if (highMax < priceHigh)
                        {
                            highMax = priceHigh;
                        }
    
                        if (lowMin > priceLow)
                        {
                            lowMin = priceLow;
                        }
    
                        if (volumeMax < volume)
                        {
                            volumeMax = volume;
                        }
    
                        if (dateTimeOut.Minute % divider == 0)
                        {
                            newLine = dateTimeOut + "," + listOpen[0] + "," + highMax + "," + lowMin + "," + listClose[4] + "," + volumeMax;
                            sw.WriteLine(newLine);
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
        }
    }
