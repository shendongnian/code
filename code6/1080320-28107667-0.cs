    private string extractDate(string line)
            {
                var splitValues = line.Split('-');
                var firstSplitted = splitValues[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var dateSplitted = firstSplitted[1].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                return new DateTime(Convert.ToInt32(dateSplitted[2]), Convert.ToInt32(dateSplitted[1]), Convert.ToInt32(dateSplitted[0])).ToString("MM/dd/yyyy"); 
            }
