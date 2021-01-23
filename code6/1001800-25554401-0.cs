    private string getBlockDataOrName(string nameOrData, string index)
    {
        String[][] blocks = {
    							new []{ "stone", "grass", "dirt", "trees", "logs", "shovel", "bedrock" },
                            	new []{ "6", "0", "2", "0", "5", "5", "0" }
    						};
    
        if (nameOrData == "Data")
            return blocks[1][Array.IndexOf(blocks[1], index)];
        else
            return blocks[0][Convert.ToInt64(index)];
    
    }
