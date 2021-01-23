    public DayOfWeek DayOfWeek
        		{
        			
        			get
        			{
        				return (DayOfWeek)(((Ticks>>14) / 52734375 + 1L) % 7L);
        			}
        		}
