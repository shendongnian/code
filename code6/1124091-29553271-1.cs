    /// <summary>
    /// Section class
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Creates a new instance of a section
        /// </summary>
        /// <param name="crn"></param>
        /// <param name="courseId"></param>
        /// <param name="timeDays"></param>
        /// <param name="roomNumber"></param>
        /// <param name="instructor"></param>
        public Section(int crn, string courseId, string timeDays, string roomNumber, int instructor)
            :this(crn, courseId, timeDays, roomNumber, instructor, "")
        {
        }
    
        /// <summary>
        /// Creates a new instance of a section
        /// </summary>
        /// <param name="crn"></param>
        /// <param name="courseId"></param>
        /// <param name="timeDays"></param>
        /// <param name="roomNumber"></param>
        /// <param name="instructor"></param>
        /// <param name="message"></param>
        public Section(int crn, string courseId, string timeDays, string roomNumber, int instructor, string message)
        {
            this.Crn = crn;
            this.CourseId = courseId;
            this.TimeDays = timeDays;
            this.RoomNumber = roomNumber;
            this.Instructor = instructor;
            this.Message = message;
        }
    
        /// <summary>
        /// Gets or sets the crn
        /// </summary>
        public int Crn { get; set; }
    
        /// <summary>
        /// gets or sets the course id
        /// </summary>
        public string CourseId { get; set; }
    
        /// <summary>
        /// gets or sets the time days
        /// </summary>
        public string TimeDays { get; set; }
    
        /// <summary>
        /// gets or sets the room number
        /// </summary>
        public string RoomNumber { get; set; }
    
        /// <summary>
        /// Gets or sets the instructor
        /// </summary>
        public int Instructor { get; set; }
    
        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message { get; set; }
    }
