    /// <summary>
    /// Schedule class
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Creates a new instance of a schedule
        /// </summary>
        public Schedule()
        {
            this.sections = new List<Section>();
        }
    
        /// <summary>
        /// collection of sections
        /// </summary>
        ICollection<Section> sections;
    
        /// <summary>
        /// Adds a section
        /// </summary>
        /// <param name="section"></param>
        public void Add(Section section)
        {
            if (section == null)
                throw new ArgumentNullException("section");
    
            this.sections.Add(section);
        }
    
        /// <summary>
        /// Drops a section
        /// </summary>
        /// <param name="section"></param>
        public void Drop(Section section)
        {
            if (section == null)
                throw new ArgumentNullException("section");
            this.sections.Remove(section);
        }
    
        /// <summary>
        /// Returns an enumerable of all the sections
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Section> Display()
        {
            return this.sections;
        }
    
    }
