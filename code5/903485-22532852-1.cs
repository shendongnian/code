**Edit:** Changed TimeStamp to double
    public class Value
    {
    	public double TimeStamp { get; set; }
    
    	public bool IsActive { get; set; }
    }
And a list of this objects called values. Then you could search for active data sets and for each of them mark the values within a range around them as active:
    double range = 1.5;
    var activeTimeStamps = values.Where(value => value.IsActive)
    							 .Select(value => value.TimeStamp)
    							 .ToList();
    foreach (var timeStamp in activeTimeStamps)
    {
    	var valuesToMakeActive =
    		values.Where
    			(
    				value =>
    					value.TimeStamp >= timeStamp - range &&
    					value.TimeStamp <= timeStamp + range
    			);
    	foreach (var value in valuesToMakeActive)
    	{
    		value.IsActive = true;
    	}
    }
