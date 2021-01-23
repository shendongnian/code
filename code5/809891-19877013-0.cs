    public class RandomArray 
    {
        /// <summary>
        /// create a single random number generator
        /// </summary>
        static readonly Random generator = new Random();
        /// <summary>
        /// here are the random numbers stored
        /// </summary>
        int[] array;
        /// <summary>
        /// store the min, max used to generate the data
        /// </summary>
        readonly int min, max;
        /// <summary>
        /// Constructor only needs how the value limits
        /// </summary>
        /// <param name="min">The minimum value (typical 0)</param>
        /// <param name="max">The maximum value (example 100)</param>
        public RandomArray(int min, int max)
        {
            this.min=min;
            this.max=max;
            this.array=new int[0];
        }
        /// <summary>
        /// Fills the array with random numbers
        /// </summary>
        /// <param name="count">The number of data to generate</param>
        public void Fill(int count)
        {
            this.array=new int[count];
            // fill array with random integers
            for (int i=0; i<array.Length; i++)
            {
                array[i]=generator.Next(min, max);
            }
        }        
        /// <summary>
        /// Copy constructor if needed (optional)
        /// </summary>
        /// <param name="other">A RandomArray to copy the data from</param> 
        public RandomArray(RandomArray other)
        {
            this.min=other.min;
            this.max=other.max;
            this.array=(int[])other.array.Clone();
        }
        /// <summary>
        /// Provide the data
        /// </summary>
 
        public int[] Array { get { return array; } }
        /// <summary>
        /// Provide the limits used
        /// </summary>
 
        public int Min { get { return min; } }
        public int Max { get { return max; } }
        /// <summary>
        /// Creates a comma separated list of numbers like <c>[45,32,64,..]</c>
        /// </summary>
        public string ToStringList()
        {
            string[] parts=new string[array.Length];
            for (int i=0; i<parts.Length; i++)
            {
                parts[i]=array[i].ToString();
            }
            return "["+string.Join(",", parts)+"]";
        }
        /// <summary>
        /// Shows only the limits used
        /// </summary>
        public override string ToString()
        {
            return string.Format("RandomArray({0},{1})", min, max);
        }
    }
        // Click Event
        private void button1_Click(object sender, EventArgs e)
        {
            RandomArray random_array=new RandomArray(0, 100);
            random_array.Fill(10);
            textBox1.Text=random_array.ToStringList();
        }
