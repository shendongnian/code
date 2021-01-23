    public class Value
    {
    	public TimeSpan TimeStamp { get; set; }
    
    	public bool IsActive { get; set; }
    }
And a list of this objects called values. Then you could search for active data sets and for each of them mark the values within a range around them as active:
    TimeSpan range = TimeSpan.FromMilliseconds(1500);
    var activeTimeStamps = values.Where(value => value.IsActive)
    							 .Select(value => value.TimeStamp)
    							 .ToList();
    foreach (var timeStamp in activeTimeStamps)
    {
    	var valuesToMakeActive =
    		values.Where
    			(
    				value =>
    					value.TimeStamp >= timeStamp.Subtract(range) &&
    					value.TimeStamp <= timeStamp.Add(range)
    			);
    	foreach (var value in valuesToMakeActive)
    	{
    		value.IsActive = true;
    	}
    }
