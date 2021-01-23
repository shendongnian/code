        private Mock<IActivityRepository> _mockActivityRepository;
        private Activity _expectedActivity = new Activity { Name = Name, Description = Details };
        /// <summary>
        /// Created by: kayz1
        /// Created: 23 jun 2011 23:48
        /// </summary>
        [Test, Description("GetAllActivities")]
        public void GetAllActivities_ValidProjects_ReturnProjects()
        {
            // Arrange
            var activities = new List<Activity> { _expectedActivity };
            _mockActivityRepository.Setup(x => x.GetAllActivities()).Returns(activities);
            // Act
            var resultList = _acitivityViewModel.GetAllActivities();
            // Assert
            _mockActivityRepository.VerifyAll();
            resultList.Should().HaveCount(1);
        }
