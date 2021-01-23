        private void btnFindPopulation_Click(object sender, EventArgs e)
        {
            StreamReader inputFile = File.OpenText("USPopulation.txt");                     //Open the USPopulation.txt file.
            List<int> PopulationList = new List<int>();                                     //Creates a list and a new object of the list.
            int startingyear = 1950;                                                        //Creates the starting year for the index.
            while (!inputFile.EndOfStream)                                                  //While not at the end of the list.
            {
                PopulationList.Add(int.Parse(inputFile.ReadLine()));                        //Read the scores into the list.
            }
            inputFile.Close();                                                              //Close the file.
           int numberOfYears = PopulationList.Count();                                      //Counts the amount of items in the population and assigns it to number of years.
           int average = Average(PopulationList, numberOfYears);                            //Sends the population list and numberofyears into average.
           lblAnnualChange.Text = average.ToString();                                       //Assigns the new average into the lblAnnualChange.
           int biggest = startingyear + GreatestIncrease(PopulationList);                   //Adds the starting year with the index count of the biggest number.
           lblGreatestIncrease.Text = biggest.ToString();                                   //Assigns the biggest into the lblGreatestIncrease.
           int least = startingyear + LeastIncrease(PopulationList);                        //Sends the population list and number of years to least number.
           lblLeastIncrease.Text = least.ToString();                                        //Assigns the least into the lblLeastIncrease.
        }
