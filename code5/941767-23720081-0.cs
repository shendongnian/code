    		private static bool SearchByHeading(Book b, string heading)
    		{
    			if (string.IsNullOrEmpty(heading))
    				return true;
    			else
    				return b.Pages.Any(p => p.Heading == heading);
    		}
