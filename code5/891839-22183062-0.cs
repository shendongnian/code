            string[] splitArray = {};
            string result = "";
            foreach (string it in responseArray)
            {
                splitArray = it.Split(' ');
                foreach (string ot in splitArray)
                {
                    if (!string.IsNullOrWhiteSpace(ot))
                        result += "-" + ot.Trim();
                }
            }
            splitArray = result.Substring(1).Split('-');
