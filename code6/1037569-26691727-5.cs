    // Remove the rows
    list = list.Where(row => row.Contains(1)).ToList();
    // Reverse the matrix and apply the same procedure to remove the columns
    list = Transpose(list);
    list = list.Where(row => row.Contains(1)).ToList();
    // Get back the original order of the rows and columns
    list = Transpose(list);
    static List<List<int>> Transpose(List<List<int>> input)
    {
        return input.ElementAt(0).Select((item, index) => 
            {
                var row = new List<int>{input[0][index]};
                input.ForEach(el => row.Add(el.ElementAt(index)));
                return row;
                }).ToList();
            }
    }
