    string niz;
                            int j=0;
                            string[] vrstica, vrstica_prej=null;
                            while (!dat.EndOfStream)
                            {
                                niz = dat.ReadLine();
                                vrstica = niz.Split('\t');
                                j++;
                                if (j < 2)
                                {
                                    sw.WriteLine(vrstica[0] + "\t" + vrstica[1] + "\t" + "0");
                                }
                                else
                                {
                                    double a = Convert.ToDouble(vrstica[0]);
                                    double a_pre = Convert.ToDouble(vrstica_prej[0]);
                                    if (a > a_pre && a > 0)
                                    {sw.WriteLine(vrstica[0] + "\t" + "1"); }
                                    else if (a < a_pre && a > 0)
                                    {sw.WriteLine(vrstica[0] + "\t" + "2"); }
                                    else if (a < a_pre && a < 0)
                                    {sw.WriteLine(vrstica[0] +"\t" + "3"); }
                                    else if (a > a_pre && a < 0)
                                    {sw.WriteLine(vrstica[0] + "\t" + "4"); }
                                }
                                vrstica_prej = vrstica;
                            }
                        }
                        sw.Close();
