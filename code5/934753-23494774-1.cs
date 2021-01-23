    case "ticket":
    	int totalScrap = 0, scrapPart1 = 0, scrapPart2 = 0, scrapPart3 = 0;
        var items = Trade.OtherOfferedItems;
    	
    	foreach (ulong id in items)
    	{
    		var itemType = Trade.OtherInventory.GetItem(id);
    		
    		//i assume you want each scrap part to be a cumulative total, so we'll add
                //it to what we already have (+=)
    		switch(itemType.Defindex)
    		{
    			case 5000:
    				scrapPart1 += items.Count;
    				break;
    			case 5001:
    				int Count = 0;
    				Count = items.Count * 3;
    				scrapPart2 += Count / items.Count;
    				break;
    			case 5002:
    				int Count1 = 0;
    				Count1 = items.Count * 9;
    				System.Console.WriteLine(Count1);
    				scrapPart3 += Count1 / items.Count;
    				break;
    		}
    	}
    	
    	//now that we are done calculating all the parts, now let's calculate the total
    	totalScrap = scrapPart1 + scrapPart2 + scrapPart3;
    	System.Console.WriteLine(scrapPart1);
    	System.Console.WriteLine(scrapPart2);
    	System.Console.WriteLine(scrapPart3);
    	System.Console.WriteLine(totalScrap);
    	break;
