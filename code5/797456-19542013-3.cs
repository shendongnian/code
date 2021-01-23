    /// <summary>
    /// Extends the normal point used by OxyPlot to include the level and the date.
    /// The Idea is to use them on the tool tip of the exercise
    /// </summary>
    class ExercisePoint : IDataPoint
    {
    	public double X { get; set; }
    	public double Y { get; set; }
    	public int Lvl { get; set; }
    	public DateTime DateTime { get; set; }
    	public string Exercise { get; set; }
    }
