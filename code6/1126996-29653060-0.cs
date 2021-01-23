    using (StreamReader reader = new StreamReader(
                    "Frequencies(Hz)_and_corresponding_SingularValues.txt"
                    ))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] tokens = line.Split(new char[] { '\t' });
                        x = Convert.ToDouble(tokens[0]);
                        y = Convert.ToDouble(tokens[1]);
                        /////////////////to skip zero/negative data points, 
                        /////////////////to avoid exceptions in logarithmic scale:
                        /////////////////singular values look like to be positive, but we add this just in case:
                        //chart1.Series["Series1"].Points.AddXY(x, y);
                        if(y>0){
                            chart1.Series["Series1"].Points.AddXY(x,y);
                        }
                    }
                }
