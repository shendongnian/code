        //create the empty array
        var result = new object[data.Count, data[0].Count];
        //insert all of the values in it
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data[i].Count; j++)
            {
                if (j < data[i].Count)
                    result[i, j] = data[i][j];
                else
                    result[i, j] = " ";
            }
        }
        //change the date time values to doubles which are 
        //in the first column after the first entry
        for (int i = 1; i < data.Count; i++)
        {
            result[i, 0] = (Convert.ToDateTime(result[i, 0])).ToOADate();
        }
            return result;
