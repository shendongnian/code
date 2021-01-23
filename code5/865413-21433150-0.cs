    public static void MyFillTest<T>(this ObservableCollection<T> value1, T value2, int nbr)
    {
        for (int x = 0; x < nbr; x++)
        {
            if (typeof(T).IsValueType)
            {
                value1.Add(value2);
            }
            else
            {
                if (value2 is ICloneable)
                {
                    ICloneable cloneable = (ICloneable)value2;
                    value1.Add((T)cloneable.Clone());
                }
            }
        }
    }
    
    public class Person : ICloneable
    {
        public string Name { get; set; }
        public int? Score { get; set; }
        public int NbrOfWins { get; set; }
        public int NbrOfLosses { get; set; }
        public int HighScore { get; set; }
    
        #region ICloneable Members
    
        public object Clone()
        {
            return new Person
            {
                Name = this.Name,
                Score = this.Score,
                NbrOfWins = this.NbrOfWins,
                NbrOfLosses = this.NbrOfLosses,
                HighScore = this.HighScore
            };
        }
    
        #endregion
    }
