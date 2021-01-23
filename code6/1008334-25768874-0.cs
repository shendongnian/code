    class CarDto
    {
        ... 
        public int StatusId { get; set; }
        public CarStatusEnum CarStatus
        {
            get { return StatusId == 2 || StatusId == 3 
                           ? CarStatusEnum.Four
                           : CarStatusEnum.Five; }
        }
    }
